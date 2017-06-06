using UnityEngine;
using System.Collections;

public class Piston : MonoBehaviour
{
	public Vector3 fromPos;
	public Vector3 toPos;
	public float duration;

	private TransformLerpCoroutine anim;

	void Start()
	{
		anim = new TransformLerpCoroutine (
			gameObject,
			fromPos,
			toPos,
			duration
		);

		GameMoniter.startChangedEvent += StartStateChanged;
	}

	void OnDisable()
	{
		GameMoniter.startChangedEvent -= StartStateChanged;
	}

	void StartStateChanged(bool started)
	{
		if (started) {
			StartCoroutine (anim.AnimationCoroutine ());
		} else {
			StopAllCoroutines ();
			transform.position = fromPos;
		}
	}
}
