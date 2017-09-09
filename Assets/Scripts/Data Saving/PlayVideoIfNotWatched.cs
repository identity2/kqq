using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayVideoIfNotWatched : MonoBehaviour 
{
	public int galaxy;
	public int sceneIndex;

	void Start()
	{
		if (GameDataLoaderAndSaver.dataControl.GetHighScore (galaxy, 0) < 0f) {
			SceneManager.LoadScene (sceneIndex);
		}
	}
}
