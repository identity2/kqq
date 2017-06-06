using UnityEngine;
using System.Collections;

public class BackgroundMusicChecker : MonoBehaviour 
{
	public bool isColor;

	void Start()
	{
		GameObject.FindObjectOfType<BackgroundMusicPlayer> ().CheckBackgroundMusic(isColor);
	}
}
