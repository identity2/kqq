using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SetLevelPicker : MonoBehaviour
{
	public int galaxy;
	public int previousGameLevel;
	public bool show;

	void Awake()
	{
		float highScore = GameDataLoaderAndSaver.dataControl.GetHighScore (galaxy, previousGameLevel);
		if (highScore < 0f) {
			if (show)
				gameObject.SetActive (false);
			else
				gameObject.SetActive (true);
		} else {
			if (show)
				gameObject.SetActive (true);
			else
				gameObject.SetActive (false);
		}
	}
		
}
