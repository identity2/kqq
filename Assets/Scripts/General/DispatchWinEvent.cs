using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispatchWinEvent : MonoBehaviour
{
	public delegate void WinAction();
	public static event WinAction winEvent;

	void Start()
	{
		if (winEvent != null)
			winEvent();
	}
}
