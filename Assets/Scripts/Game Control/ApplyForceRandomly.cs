using UnityEngine;
using System.Collections;

public class ApplyForceRandomly : MonoBehaviour 
{
	[Header("Clamp Between Boarders")]
	public Vector2 minPos;
	public Vector2 maxPos;

	[Header("Force")]
	public float minForce;
	public float maxForce;

	[Header("Interval")]
	public float minInterval;
	public float maxInterval;

	void Update()
	{
		transform.position = new Vector2 (Mathf.Clamp (transform.position.x, minPos.x, maxPos.x), Mathf.Clamp (transform.position.y, minPos.y, maxPos.y));
	}

	void Start()
	{
		StartCoroutine (ApplyForce ());
	}

	IEnumerator ApplyForce()
	{
		while (true) {
			float xForce = Random.Range (minForce, maxForce);
			float yForce = Random.Range (minForce, maxForce);
			GetComponent<Rigidbody2D> ().AddForce (new Vector2(Random.value > .5f ? xForce : -xForce, Random.value > .5f ? yForce : -yForce));
			yield return new WaitForSeconds (Random.Range (minInterval, maxInterval));
		}
	}
}
