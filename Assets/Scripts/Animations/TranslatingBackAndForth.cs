using UnityEngine;
using System.Collections;

public class TranslatingBackAndForth : MonoBehaviour {
	public Vector3 fromPos;
	public Vector3 toPos;
	public float moveTime;
	public float stopTime;
	private TransformLerpCoroutine anim;

	void Start()
	{
		anim = new TransformLerpCoroutine (
			gameObject,
			fromPos,
			toPos,
			moveTime,
			true
		);

		StartCoroutine (Cycle ());
	}

	IEnumerator Cycle()
	{
		while (true) {
			StartCoroutine (anim.AnimationCoroutine ());
			yield return new WaitForSeconds (moveTime + stopTime);

			StartCoroutine (anim.AnimationCoroutine (true));
			yield return new WaitForSeconds (moveTime + stopTime);
		}
	}
}
