using UnityEngine;
using System.Collections;

public class SpriteColorLerpCoroutine
{

	private Color startColor;
	private Color endColor;
	private float duration;

	private SpriteRenderer spriteRenderer;

	public SpriteColorLerpCoroutine(GameObject objectiveGameObject, Color startColor, Color endColor, float duration) 
	{
		this.duration = duration;
		this.startColor = startColor;
		this.endColor = endColor;
		spriteRenderer = objectiveGameObject.GetComponent<SpriteRenderer> ();
	}

	public IEnumerator AnimationCoroutine(bool back = false)
	{
		float i = 0f;
		while (i <= 1f) {
			i += Time.deltaTime / duration;
			Color newColor = Color.Lerp (startColor, endColor, back ? (1f - i) : i);
			spriteRenderer.color = newColor;
			yield return null;
		}
	}
}
