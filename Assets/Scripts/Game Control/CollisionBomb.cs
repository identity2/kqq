using UnityEngine;
using System.Collections;

public class CollisionBomb : MonoBehaviour 
{
	public GameObject explosionPrefab;
	public GameObject explodeAudio;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			Explode ();
		}
	}

	void Explode()
	{
		gameObject.SetActive (false);
		Instantiate (explosionPrefab, transform.position, Quaternion.identity);
		Instantiate (explodeAudio, Vector2.zero, Quaternion.identity);
	}

	void Start()
	{
		GameMoniter.startChangedEvent += StartStateChanged;
	}

	void OnDestroy()
	{
		GameMoniter.startChangedEvent -= StartStateChanged;
	}

	void StartStateChanged(bool started)
	{
		if (!started) {
			gameObject.SetActive (true);
		}
	}
}
