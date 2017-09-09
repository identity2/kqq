using UnityEngine;
using System.Collections;

public class AddButtonToMonitor : MonoBehaviour 
{
	void Start()
	{
		GameMoniter.Instance.buttons.Add (gameObject);
	}
}
