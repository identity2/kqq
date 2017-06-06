using UnityEngine;
using System.Collections;

public class DeleteWhenRestart : MonoBehaviour 
{
	void Start()
	{
		GameMoniter.startChangedEvent += StartStateChanged;
	}

	void StartStateChanged(bool started)
	{
		if (!started) {
			Destroy (gameObject);
		}
	}

	void OnDestroy()
	{
		GameMoniter.startChangedEvent -= StartStateChanged;
	}
}
