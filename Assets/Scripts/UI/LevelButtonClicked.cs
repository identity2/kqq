using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelButtonClicked : MonoBehaviour
{
	public GameObject scoreIndicatorPrefab;
	public LevelInformation info;

	void Start()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			ButtonClicked ();
		});
	}

	void ButtonClicked()
	{
		GameObject indicator = (Instantiate (scoreIndicatorPrefab, Vector2.zero, Quaternion.identity) as GameObject);
		indicator.GetComponent<ScoreIndicator> ().Galaxy = info.galaxy;
		indicator.GetComponent<ScoreIndicator> ().Level = info.level;
		indicator.GetComponent<ScoreIndicator> ().SceneIndex = info.sceneIndex;
		if (Application.systemLanguage == SystemLanguage.Chinese ||
			Application.systemLanguage == SystemLanguage.ChineseSimplified ||
			Application.systemLanguage == SystemLanguage.ChineseTraditional)
			indicator.GetComponent<ScoreIndicator> ().LevelName = info.chineseName;
		else
			indicator.GetComponent<ScoreIndicator> ().LevelName = info.englishName;

		indicator.GetComponent<ScoreIndicator> ().UpdateText ();
	}
}
