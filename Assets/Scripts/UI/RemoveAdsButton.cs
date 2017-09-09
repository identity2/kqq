using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAdsButton : MonoBehaviour 
{
	public void OnClicked()
	{
		InAppPurchaser.Instance.BuyRemoveAds();
	}
}
