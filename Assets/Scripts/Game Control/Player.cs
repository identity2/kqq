using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private Vector2 originalPosition;
	private Rigidbody2D rb { get { return GetComponent<Rigidbody2D> (); } }
	private CircleCollider2D col { get { return GetComponent<CircleCollider2D> (); } }

	void Start()
	{
		GameMoniter.Instance.player = this.gameObject;
		GameMoniter.startChangedEvent += StartStateChanged;

		originalPosition = transform.position;
	}

	public void ResetPosition()
	{
		//avoid moving
		rb.velocity = Vector2.zero;
		rb.isKinematic = true;

		//avoid spinning
		rb.angularVelocity = 0f;

		//to the original spot
		transform.position = originalPosition;

		//to the original rotation
		transform.rotation = Quaternion.identity;

		//back to trigger
		GetComponent<CircleCollider2D> ().isTrigger = true;

		//reset color (color portals could change the alpha of player)
		GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 1f);
	}

	void StartStateChanged(bool started)
	{
		if (started) {
			col.isTrigger = false;
		    rb.isKinematic = false;
		} else {
			ResetPosition ();
		}
	}

	void OnDisable()
	{
		GameMoniter.startChangedEvent -= StartStateChanged;
	}
}
