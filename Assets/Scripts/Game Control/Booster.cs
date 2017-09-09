using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour 
{
	public float magnitude;
	public GameObject boostAudio;

	private bool exitted = true;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (exitted && col.gameObject.tag == "Player") {
			exitted = false;
			col.gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.up * magnitude);
			Instantiate (boostAudio, Vector2.zero, Quaternion.identity);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			exitted = true;
		}
	}
}

