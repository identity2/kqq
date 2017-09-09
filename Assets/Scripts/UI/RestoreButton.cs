using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreButton : MonoBehaviour 
{
	void Start() 
	{
		#if UNITY_ANDROID
		gameObject.SetActive(false);
		#endif
	}

	public void OnClicked()
	{
		InAppPurchaser.Instance.RestorePurchases();
	}
}
