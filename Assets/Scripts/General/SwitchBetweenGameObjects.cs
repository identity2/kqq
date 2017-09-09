using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBetweenGameObjects : MonoBehaviour 
{
	public GameObject first;
	public float firstDuration;

	public GameObject second;
	public float secondDuration;

	void Start()
	{
		StartCoroutine (Cycle ());
	}

	IEnumerator Cycle()
	{
		while (true) {
			yield return new WaitForSeconds (firstDuration);

			first.SetActive (false);
			second.SetActive (true);

			yield return new WaitForSeconds (secondDuration);

			second.SetActive (false);
			first.SetActive (true);
		}
	}
}
