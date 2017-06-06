using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayMovieOnStartAndGoToScene : MonoBehaviour 
{
	public int galaxy;
	public int goToSceneAfterMovie;
	public string movieName;

	void Start()
	{
		StartCoroutine (AnimationCoroutine ());
	}

	IEnumerator AnimationCoroutine()
	{
		Handheld.PlayFullScreenMovie (movieName);
		yield return new WaitForEndOfFrame ();

		//recorded that video is watched
		GameDataLoaderAndSaver.dataControl.SetHighScoreAndSave(galaxy, 0, 1f);

		//after playing the movie, go to game scene
		SceneManager.LoadScene (goToSceneAfterMovie);
	}
}
