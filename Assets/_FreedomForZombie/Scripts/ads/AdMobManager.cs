using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class AdMobManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AdMobManager instance;
    private InterstitialAd FullScreenAD;
    private RewardedAd rewardedAd;
    private BannerView bannerView;

    [SerializeField] private bool _isNeedLoadFullScreenAD;
    [SerializeField] private bool _isNeedLoadRequestRewardedAdFor;

    public UnityEvent RewardedAdShowed;
    public UnityEvent RewardedAdLoaded;
    public UnityEvent RewardedAdFailedToLoad;
    //[Header("UI")]
    //[SerializeField] private Button playBtn;


    private string rewardId = "ca-app-pub-4425759167125218/3468759497";
    private string fullScreenId = "ca-app-pub-4425759167125218/5432660003";
    private string bannerId = "";

    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        MobileAds.Initialize(status => {
            if (_isNeedLoadFullScreenAD)
                RequestFullScreenAD();
            if (_isNeedLoadRequestRewardedAdFor)
                RequestAndLoadRewardedAd();
        });
        


    }
    public void RequestFullScreenAD()
    {
        FullScreenAD = new InterstitialAd(fullScreenId);
               
        // Called when an ad request has successfully loaded.
        FullScreenAD.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        FullScreenAD.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        FullScreenAD.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        FullScreenAD.OnAdClosed += HandleOnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();

        FullScreenAD.LoadAd(request);
        //FullScreenAD.Show();
    }


    public bool isLoadedFullScreenAD()
    {
        if (FullScreenAD.IsLoaded())
        {
            return true;
        }
        return false;
        
    }
    public void ShowFullScreenAD()
    {
        FullScreenAD.Show();
    }
    public void RequestAndLoadRewardedAd()
    {
        // create new rewarded ad instance
        rewardedAd = new RewardedAd(rewardId);
        // Add Event Handlers
        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when failed to load.
        rewardedAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        // Create empty ad request
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(request);
    }


    public void ShowRewardAd()
    {
        rewardedAd.Show();
    }

    public void HideBanner()
    {
        this.bannerView.Hide();
    }public void ShowBanner()
    {
        this.bannerView.Show();
    }
   

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
       Debug.Log("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
       // status.text = "HandleFailedToReceiveAd event received with message: " + args.Message;
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
       // status.text = "HandleAdOpened event received";
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
      //  status.text = "HandleAdClosed event received";
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
      //  status.text = "HandleAdLeavingApplication event received";
    }


    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        RewardedAdLoaded?.Invoke();
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        RewardedAdFailedToLoad?.Invoke();
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedCoinsReward(object sender, Reward args)
    {
      
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        RewardedAdShowed?.Invoke();
    }
}
