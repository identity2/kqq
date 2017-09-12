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

		if (!GameDataLoaderAndSaver.dataControl.SholdShowAds())
		{
			gameObject.SetActive(false);
		}
	}

	public void OnClicked()
	{
		InAppPurchaser.Instance.RestorePurchases();
	}
}
