using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstantiateObject : MonoBehaviour 
{
	public GameObject countText;
	public int unitLimit;

	public GameObject go;
	public Vector3 pos;

	void OnEnable()
	{
		ResetText ();
	}

	public void InstantiateObj()
	{
		if (unitLimit > 0) {
			unitLimit--;
			ResetText ();
			Instantiate (go, pos, Quaternion.identity);
		}
	}

	void ResetText()
	{
		countText.GetComponent<Text> ().text = "x" + unitLimit;
	}

	public void AddUnitLimit()
	{
		unitLimit++;
		ResetText();
	}
}
