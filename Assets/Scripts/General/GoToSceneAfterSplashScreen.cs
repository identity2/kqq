using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class GoToSceneAfterSplashScreen : MonoBehaviour 
{
	public int sceneIndex;

	private bool called = false;

	void Update()
	{
		if (!called && SplashScreen.isFinished)
		{
			called = true;
			SceneManager.LoadSceneAsync(sceneIndex);
		}
	}
}
