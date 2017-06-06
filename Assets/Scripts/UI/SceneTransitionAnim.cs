using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransitionAnim : MonoBehaviour 
{
	public int startSceneIndex;
	public Image blackScreenImage;
	public float duration;

	public static SceneTransitionAnim instance = null;


	public void FadeOutAndGotoScene(int sceneIndex)
	{
		StartCoroutine(AnimationCoroutine(false, sceneIndex));
	}

	public void FadeIn(Scene scene, LoadSceneMode mode)
	{
		if (scene.buildIndex != startSceneIndex)
		{
			StartCoroutine(AnimationCoroutine());
		}
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += FadeIn;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= FadeIn;
	}

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	IEnumerator AnimationCoroutine(bool fadeIn = true, int gotoScene = 0)
	{
		blackScreenImage.gameObject.SetActive(true);
		float i = 0f;
		while (i <= 1f)
		{
			i += Time.deltaTime / duration;
			blackScreenImage.color = Color.Lerp(Color.black, new Color(0f, 0f, 0f, 0f), fadeIn ? i : (1f-i));
			yield return null;
		}
		if (!fadeIn) SceneManager.LoadScene(gotoScene);
		else blackScreenImage.gameObject.SetActive(false);
	}
}
