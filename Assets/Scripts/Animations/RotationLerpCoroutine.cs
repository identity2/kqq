using UnityEngine;
using System.Collections;

public class RotationLerpCoroutine
{
	private GameObject objectiveGameObject;
	private float startAngle;
	private float endAngle;
	private float duration;
	private bool local;
	
	public RotationLerpCoroutine(GameObject objectiveGameObject, float startAngle, float endAngle, float duration, bool local = false)
	{
		this.objectiveGameObject = objectiveGameObject;
		this.startAngle = startAngle;
		this.endAngle = endAngle;
		this.duration = duration;
		this.local = local;
	}
		
	public IEnumerator AnimationCoroutine(bool back = false)
	{
		float i = 0f;
		while (i <= 1f) {
			i += Time.deltaTime / duration;
			Quaternion newQuat = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Lerp(startAngle, endAngle, back ? (1-i):i)));
			if (local)
				objectiveGameObject.transform.localRotation = newQuat;
			else
				objectiveGameObject.transform.rotation = newQuat;
			yield return null;
		}
	}
}
