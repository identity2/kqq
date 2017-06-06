using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCanvas : MonoBehaviour
{
	public Sprite[] tutorialImages;

	public TextLanguageSetting[] tutorialTexts;

	public Image centerImage;
	public Text bottomText;

	public Button backButton;
	public Button nextButton;

	private int currIndex = 0;
	private int lastIndex;

	void Start()
	{
		lastIndex = tutorialImages.Length - 1;

		centerImage.sprite = tutorialImages [0];
		tutorialTexts [0].SetLanguage (bottomText.gameObject);

		backButton.onClick.AddListener (() => {
			BackButtonClicked ();
		});
		backButton.gameObject.SetActive (false);

		nextButton.onClick.AddListener (() => {
			NextButtonClicked ();
		});
	}

	void NextButtonClicked()
	{
		currIndex++;

		SetCanvas (currIndex);
	}

	void BackButtonClicked()
	{
		currIndex--;

		SetCanvas (currIndex);
	}

	void SetCanvas(int index)
	{
		//last pic
		if (index > lastIndex) {
			Destroy (gameObject);
			return;
		} else if (index == 0) {
			backButton.gameObject.SetActive (false);
		} else {
			backButton.gameObject.SetActive (true);
		}

		//update image
		centerImage.sprite = tutorialImages [index];

		//update text
		tutorialTexts [index].SetLanguage (bottomText.gameObject);
	}
}
