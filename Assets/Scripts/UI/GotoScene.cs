using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GotoScene : MonoBehaviour 
{
	public int scene;
	public bool backButtonPress = false;

	void Start()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			ButtonClicked ();
		});
	}

	#if UNITY_ANDROID || UNITY_EDITOR
	void Update()
	{
		if (backButtonPress && Input.GetKeyDown (KeyCode.Escape) && FindObjectOfType<ScoreIndicator>() == null) {
			ButtonClicked ();
		}
	}
	#endif

	void ButtonClicked()
	{
		SceneTransitionAnim.instance.FadeOutAndGotoScene(scene);
	}
}
