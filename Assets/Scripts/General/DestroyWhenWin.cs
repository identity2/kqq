using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenWin : MonoBehaviour 
{
	void Awake()
	{
		DispatchWinEvent.winEvent += DestroySelf;
	}

	void DestroySelf()
	{
		Destroy(gameObject);
	}

	void OnDestroy()
	{
		DispatchWinEvent.winEvent -= DestroySelf;
	}
}
