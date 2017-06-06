using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour 
{
	public float fadeInAfterSec;

	public float duration;

	public Color fromColor;
	public Color toColor;

	private Text _text;

	void Start()
	{
		_text = GetComponent<Text> ();

		_text.color = fromColor;

		StartCoroutine (AnimationCoroutine ());
	}

	IEnumerator AnimationCoroutine()
	{
		yield return new WaitForSeconds (fadeInAfterSec);

		float i = 0f;
		while (i <= 1f) {
			i += Time.deltaTime / duration;
			_text.color = Color.Lerp (fromColor, toColor, i);
			yield return null;
		}
	}
}
