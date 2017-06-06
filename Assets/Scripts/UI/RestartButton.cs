using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour 
{
	void Start()
	{
		GameMoniter.Instance.restartButton = gameObject;
		GetComponent<Button> ().onClick.AddListener (() => {
			OnClickFunc ();
		});
		gameObject.SetActive (false);
	}

	void OnClickFunc()
	{
		GameMoniter.Instance.Started = false;
	}
}
