using UnityEngine;
using System.Collections;

public class ScalingLerpCoroutine
{
	private GameObject objectiveGameObject;
	private Vector3 startScale;
	private Vector3 endScale;
	private float duration;

	public ScalingLerpCoroutine(GameObject go, Vector3 startScale, Vector3 endScale, float duration)
	{
		this.objectiveGameObject = go;
		this.startScale = startScale;
		this.endScale = endScale;
		this.duration = duration;
	}

	public IEnumerator AnimationCoroutine(bool backWard = false)
	{
		float i = 0f;
		while (i <= 1f) {
			i += Time.deltaTime / duration;
			Vector3 newPos = backWard ? Vector3.Lerp (endScale, startScale, i) : Vector3.Lerp (startScale, endScale, i);
			objectiveGameObject.transform.localScale = newPos;
			yield return null;
		}
	}
		
}
