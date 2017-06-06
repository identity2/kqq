using UnityEngine;
using System.Collections;

public class DestroyInSeconds : MonoBehaviour 
{
	public float existTime;

	void Start()
	{
		Invoke ("DestroyObject", existTime);
	}

	void DestroyObject()
	{
		Destroy (gameObject);
	}
}
