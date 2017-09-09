using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPopUpMenu : MonoBehaviour 
{
	public static NotificationPopUpMenu Instance;
	public Text messageText;

	void Awake () {
		Instance = this;
		gameObject.SetActive(false);
	}
	
	void Update () {
		
	}
	public void Show(string message)
	{
		messageText.text = message;
		gameObject.SetActive(true);
	}

	public void ClosePopUp()
	{
		gameObject.SetActive(false);
	}
}
