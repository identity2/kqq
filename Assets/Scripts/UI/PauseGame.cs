using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour 
{
	void Start()
	{
		Time.timeScale = 0f;
	}

	void OnDestroy()
	{
		Time.timeScale = 1f;
	}
}
