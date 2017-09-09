using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobRequest : MonoBehaviour
{
	public static BannerView bannerView;
	void Start()
	{
		if (GameDataLoaderAndSaver.dataControl.SholdShowAds())
		{
			#if UNITY_EDITOR
				string adUnitId = "unused";
			#elif UNITY_ANDROID
				string adUnitId = "ca-app-pub-3679599074148025/4678433386";
			#elif UNITY_IPHONE
				string adUnitId = "ca-app-pub-3679599074148025/1352721459";
			#else
				string adUnitId = "unexpected_platform";
			#endif

			// Create a 320x50 banner at the top of the screen.
			bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
			// Create an empty ad request.
			AdRequest request = new AdRequest.Builder().Build();
			// Load the banner with the request.
			bannerView.LoadAd(request);
		}
	}

	public static void DestroyBannerView()
	{
		if (bannerView != null)
			bannerView.Destroy();
	}
}
