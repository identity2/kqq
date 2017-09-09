using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boundary : MonoBehaviour 
{
	public GameObject sound;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			
			//reset
			GameMoniter.Instance.Started = false;
			Instantiate (sound, Vector2.zero, Quaternion.identity);
		}
	}
}
