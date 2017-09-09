using UnityEngine;
using System.Collections;

public class EnableAfterSeconds : MonoBehaviour 
{
	public float time;

	void Start()
	{
		Invoke ("EnableObject", time);
		gameObject.SetActive (false);
	}

	void EnableObject()
	{
		gameObject.SetActive (true);
	}
}
