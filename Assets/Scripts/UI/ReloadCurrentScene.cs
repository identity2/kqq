using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReloadCurrentScene : MonoBehaviour 
{
	public void ButtonClicked()
	{
		Scene currScene = SceneManager.GetActiveScene ();
		SceneTransitionAnim.instance.FadeOutAndGotoScene(currScene.buildIndex);
		//SceneManager.LoadScene (currScene.buildIndex);
		//GameObject.FindWithTag ("Background Music").GetComponent<BackgroundMusicPlayer> ().SwitchMusic ();
	}
}
