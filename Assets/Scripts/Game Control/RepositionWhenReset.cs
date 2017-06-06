using UnityEngine;
using System.Collections;

public class RepositionWhenReset : MonoBehaviour 
{
	private Vector3 startPos;
	private Quaternion startRot;

	private Rigidbody2D rb { get { return GetComponent<Rigidbody2D> (); } }
	private Collider2D col { get { return GetComponent<Collider2D> (); } }

	void Start()
	{
		startPos = transform.position;
		startRot = transform.rotation;
		col.enabled = false;
		rb.isKinematic = true;

		GameMoniter.startChangedEvent += StartStateChanged;
	}

	void OnDestroy()
	{
		GameMoniter.startChangedEvent -= StartStateChanged;
	}

	void StartStateChanged(bool start)
	{
		if (!start) {
			col.enabled = false;
			rb.isKinematic = true;
			rb.velocity = Vector2.zero;
			rb.angularVelocity = 0f;
			transform.rotation = startRot;
			transform.position = startPos;
		} else {
			col.enabled = true;
			rb.isKinematic = false;
		}
	}
}
