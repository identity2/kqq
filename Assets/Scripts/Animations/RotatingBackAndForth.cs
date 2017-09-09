using UnityEngine;
using System.Collections;

public class RotatingBackAndForth : MonoBehaviour 
{
	public float fromAngle;
	public float toAngle;
	public float moveTime;
	public float stopTime;

	private RotationLerpCoroutine anim;

	void Start () 
	{

		anim = new RotationLerpCoroutine (
			gameObject,
			fromAngle,
			toAngle,
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
