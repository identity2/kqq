using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPopUpMenu : MonoBehaviour 
{
	public static NotificationPopUpMenu Instance = null;
	public Text messageText;

	void Awake () {
		if (Instance == null)
		{
			Instance = this;
			gameObject.SetActive(false);
			DontDestroyOnLoad(gameObject);
		} else if (Instance != this) {
			Destroy(gameObject);
		}
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
