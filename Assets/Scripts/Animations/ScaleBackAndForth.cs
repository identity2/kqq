using UnityEngine;
using System.Collections;

public class ScaleBackAndForth : MonoBehaviour {
	public Vector3 fromScale;
	public Vector3 toScale;
	public float scaleTime;
	public float stopTime;
	private ScalingLerpCoroutine anim;

	void Start()
	{
		anim = new ScalingLerpCoroutine (
			gameObject,
			fromScale,
			toScale,
			scaleTime
		);

		StartCoroutine (Cycle ());
	}

	IEnumerator Cycle()
	{
		while (true) {
			StartCoroutine (anim.AnimationCoroutine ());
			yield return new WaitForSeconds (scaleTime + stopTime);

			StartCoroutine (anim.AnimationCoroutine (true));
			yield return new WaitForSeconds (scaleTime + stopTime);
		}
	}
}
