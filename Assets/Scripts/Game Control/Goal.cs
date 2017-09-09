using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour 
{
	public GameObject winScene;
	public int toIndex;
	public GameObject winAudio;

	private const int LevelSubstracter = 1;
	private const float GoalCompleteAnimationTime = 1.33f;

	private Animator anim { get { return GetComponent<Animator> (); } }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			//remove restart button
			GameMoniter.Instance.restartButton.SetActive(false);

			//start animation
			StartCoroutine (CompleteCoroutine ());

			//remove player
			col.gameObject.SetActive (false);
		}
	}

	IEnumerator CompleteCoroutine()
	{
		anim.SetTrigger ("Complete");
		yield return new WaitForSeconds (GoalCompleteAnimationTime);

		//instantiate win scene
		SetWinScene setWinScene = (Instantiate (winScene, Vector2.zero, Quaternion.identity) as GameObject).GetComponent<SetWinScene>();
		if (setWinScene != null) //last level win scene doesn't have "SetWinScene"
			setWinScene.SetNextLevelToLevelIndex(toIndex);

		//play sound, stop background music
		//GameObject.FindWithTag("Background Music").GetComponent<BackgroundMusicPlayer>().StopMusic();
		Instantiate(winAudio, Vector2.zero, Quaternion.identity);

		//record the score if it breaks the record
		LevelInformation leveInfo = GameMoniter.Instance.leveInfo;
		float previousHighScore = GameDataLoaderAndSaver.dataControl.GetHighScore (leveInfo.galaxy, leveInfo.level);
		if (previousHighScore < 0f || GameMoniter.Instance.Score < previousHighScore) {
			GameDataLoaderAndSaver.dataControl.SetHighScoreAndSave (leveInfo.galaxy, leveInfo.level, GameMoniter.Instance.Score);
		}
	}
}
