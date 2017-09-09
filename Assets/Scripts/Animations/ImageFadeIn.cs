using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageFadeIn : MonoBehaviour 
{
	public float startAfterSeconds;
	public float duration;

	void Start()
	{
		GetComponent<Image> ().color = new Color (255f, 255f, 255f, 0f);
		Invoke ("CallAfterSeconds", startAfterSeconds);
	}

	void CallAfterSeconds()
	{
		StartCoroutine (FadeLerp());
	}

	IEnumerator FadeLerp()
	{
		float i = 0f;
		while (i <= 1) {
			i += Time.deltaTime / duration;
			GetComponent<Image> ().color = new Color (255f, 255f, 255f, i);
			yield return null;
		}
	}
}
