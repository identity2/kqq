using UnityEngine;
using System.Collections;

public class TimeObjectGoal : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			GetComponent<TranslateFromTo> ().enabled = false;
		}
	}
}
