using UnityEngine;
using System.Collections;

public class CollisionSoundWithPlayer : MonoBehaviour 
{
	public GameObject collisionSound;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			Instantiate (collisionSound, Vector2.zero, Quaternion.identity);
		}
	}
}
