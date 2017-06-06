using UnityEngine;
using System.Collections;

public class SpawnInInterval : MonoBehaviour 
{
	public GameObject prefab;
	public float callToStart = 0f;
	public float interval;

	void Start()
	{
		InvokeRepeating ("Spawn", callToStart, interval);
	}

	void Spawn()
	{
		Instantiate (prefab, transform.position, transform.rotation);
	}
}
