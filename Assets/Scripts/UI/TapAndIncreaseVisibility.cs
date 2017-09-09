using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapAndIncreaseVisibility : MonoBehaviour 
{
	public void OnTouchDown(float increaseAmount)
	{
		Color currColor = GetComponent<Image> ().color;
		GetComponent<Image> ().color = new Color (currColor.r, currColor.g, currColor.b, Mathf.Clamp (currColor.a + increaseAmount, 0f, 1f));
	}
}
