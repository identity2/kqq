using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAdsButton : MonoBehaviour 
{
	void Start()
	{
		if (!GameDataLoaderAndSaver.dataControl.SholdShowAds())
		{
			gameObject.SetActive(false);
		}
	}

	public void OnClicked()
	{
		InAppPurchaser.Instance.BuyRemoveAds();
	}
}
