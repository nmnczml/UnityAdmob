using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour
{

    //Sample ad unit ID
    //App Open    ca-app-pub-3940256099942544/3419835294
    //Banner ca-app-pub-3940256099942544/6300978111
    //Interstitial ca-app-pub-3940256099942544/1033173712
    //Interstitial Video  ca-app-pub-3940256099942544/8691691433
    //Rewarded ca-app-pub-3940256099942544/5224354917
    //Rewarded Interstitial   ca-app-pub-3940256099942544/5354046379
    //Native Advanced ca-app-pub-3940256099942544/2247696110
    //Native Advanced Video ca-app-pub-3940256099942544/1044960115

     
    public static AdManager instance;

    public AdPosition position;

    public bool isTesting = false;

    [Header("To find device Id try \"Device ID Finder for AdMob\" App")]
    public string Device_ID = "";

    private BannerView bannerView;
    private InterstitialAd interstitial;

    public string IosBannerAdId;
    public string IosIntAdId;

    public string AndroidBannerAdId;
    public string AndroidIntAdId;


    void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void RequestBanner()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
            string adUnitId = AndroidBannerAdId;
#elif UNITY_IOS
            string adUnitId = IosBannerAdId;
#endif
        if (adUnitId != "unused")
        {

            bannerView = new BannerView(adUnitId, AdSize.SmartBanner, position);

            
            AdRequest request = new AdRequest.Builder().Build();

            // Register for ad events.
            bannerView.OnAdLoaded += HandleAdLoaded;
            bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;

            bannerView.LoadAd(request);
        }
    }

    //we use this methode to get the Interstitial ads
    public void RequestInterstitial()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
            string adUnitId = AndroidIntAdId;
#elif UNITY_IOS
            string adUnitId = IosIntAdId;
 
#endif
        if (adUnitId != "unused")
        {


            // Create an interstitial.
            interstitial = new InterstitialAd(adUnitId);
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();

            interstitial.LoadAd(request);
        }
    }

    // the following method is used when we are testing the ads
    private AdRequest createAdRequest()
    {
        return new AdRequest.Builder()
               
                .Build();
    }

    //.............................................................Methods used to show for ads
    //use this methode to show ads
    public void ShowInterstitial()
    {

#if UNITY_EDITOR
        Debug.Log("Interstitial Working");
#elif UNITY_ANDROID || UNITY_IOS
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            
            RequestInterstitial();
        }
#endif

    }

    //this methode is used to call the banner ads
    public void ShowBannerAds()
    {
#if UNITY_EDITOR
        print("Banner Shown");

#else
        bannerView.Show();
#endif
    }

    //this methode is used to hide banner ads
    public void HideBannerAds()
    {
        bannerView.Hide();
    }

    //this methode is used to destroy banner ads
    public void DestroyBannerAds()
    {
        bannerView.Destroy();
    }

 
    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Ad Loaded");
     }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Ad Failed To Load");

    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        Debug.Log("Ad Opened");

    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        Debug.Log("Ad Closed");

    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        Debug.Log("Ad Left Application");

    }

    #endregion

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        Debug.Log("Interstitial Ad Loaded");

    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Interstitial Ad Failed To Load");

    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        Debug.Log("Interstitial Ad Opened");

    }

    void HandleInterstitialClosing(object sender, EventArgs args)
    {
        Debug.Log("Interstitial Ad Closing");

    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        Debug.Log("Interstitial Ad Closed");

    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        Debug.Log("Interstitial Ad Left Application");

    }

    #endregion



}
