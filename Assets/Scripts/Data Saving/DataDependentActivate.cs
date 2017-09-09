using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDependentActivate : MonoBehaviour 
{
	public bool activate = true;

	public int dependentGalaxy;
	public int dependentLevel;

	public bool waitEndOfFrame = false;

	void OnEnable()
	{
		if (waitEndOfFrame) {
			StartCoroutine (WaitCoroutine ());
		} else {
			Check ();
		}

	}

	IEnumerator WaitCoroutine()
	{
		yield return new WaitForEndOfFrame ();

		Check ();
	}

	void Check()
	{
		if (GameDataLoaderAndSaver.dataControl.GetHighScore (dependentGalaxy, dependentLevel) > 0f) {
			gameObject.SetActive (activate);
		} else {
			gameObject.SetActive (!activate);
		}
	}
}
