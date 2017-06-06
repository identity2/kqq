using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour 
{
	public GameObject soundObject;

	private Button button { get { return GetComponent<Button>(); }}

	void Start()
	{
		button.onClick.AddListener (() => { Instantiate(soundObject, Vector2.zero, Quaternion.identity);});
	}
}
