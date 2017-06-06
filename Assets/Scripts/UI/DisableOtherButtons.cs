using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisableOtherButtons : MonoBehaviour 
{
	public GameObject[] buttons;

	public void DisableTheButtons()
	{
		foreach (GameObject button in buttons) 
		{
			button.SetActive(false);		
		}
	}
}
