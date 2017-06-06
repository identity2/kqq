using UnityEngine;
using System.Collections;

public class Eyeball : MonoBehaviour 
{
	public float movingSpeed;

	private Rigidbody2D rb { get { return GetComponent<Rigidbody2D> (); } }

	void FixedUpdate()
	{
		rb.velocity = (GameMoniter.Instance.player.transform.position - transform.position).normalized * movingSpeed;
	}
}
