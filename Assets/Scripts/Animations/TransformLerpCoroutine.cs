using UnityEngine;
using System.Collections;

public class TransformLerpCoroutine
{
	private GameObject objectiveGameObject;
	private Vector3 startPos;
	private Vector3 endPos;
	private float duration;
	private bool local;

	public TransformLerpCoroutine(GameObject go, Vector3 startPos, Vector3 endPos, float duration, bool local = false)
	{
		this.objectiveGameObject = go;
		this.startPos = startPos;
		this.endPos = endPos;
		this.duration = duration;
		this.local = local;
	}
		
	public IEnumerator AnimationCoroutine(bool backWard = false)
	{
		float i = 0f;
		while (i <= 1f) {
			i += Time.deltaTime / duration;
			Vector3 newPos = backWard ? Vector3.Lerp (endPos, startPos, i) : Vector3.Lerp (startPos, endPos, i);
			if (local)
				objectiveGameObject.transform.localPosition = newPos;
			else
				objectiveGameObject.transform.position = newPos;
			yield return null;
		}
	}

	public void ResetProperties(Vector3 startPos, Vector3 endPos, float duration)
	{
		this.startPos = startPos;
		this.endPos = endPos;
		this.duration = duration;
	}
}
