
using UnityEngine;
using UnityEngine.Advertisements;
using static EnumsData;

public class UnityAdsShan : MonoBehaviour, IUnityAdsListener
{
    public static UnityAdsShan inst = null;
#if UNITY_IOS
        private string gameId = "3853820";
#elif UNITY_ANDROID
    private string gameId = "3853821";
#else
        private string gameId = "3853821";
#endif

    string videoRewardPlacementID = "fullvideo";
    string videoBreakPlacementID = "videobreak";
    //bool testMode = false;

    public WatchAdOption playerWatchDecition = WatchAdOption.NotYet;
    
    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, false);
        Advertisement.debugMode = false;

    }

    public void showVideoBreak()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(videoBreakPlacementID);
        }
    }

    public void showRewardVideo()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(videoRewardPlacementID);
        }
        else
        {
            UIManager.inst.onCancleRewardClicked();
        }
    }


    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
      
        if (placementId == videoRewardPlacementID)
        {
            if (showResult == ShowResult.Finished)
            {
                setPlayerDeciction(WatchAdOption.YesPlayerFinishedWatching);
                GameManager.inst.deathCheckBasedonAds();
            }
            else
            {
                setPlayerDeciction(WatchAdOption.NoPlayerNotInterested);
                GameManager.inst.deathCheckBasedonAds();
            }
        }
     
    }

    public void OnUnityAdsReady(string placementId)
    {
       
    }

    public void OnUnityAdsDidError(string message)
    {
        if (GameManager.inst.isAboutToDie)
        {
            setPlayerDeciction(WatchAdOption.NoPlayerNotInterested);
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }
    
    public void resetDecideValue()
    {
        playerWatchDecition = WatchAdOption.NotYet;
    }

    public void setPlayerDeciction(WatchAdOption optionValue)
    {
        playerWatchDecition = optionValue;
    }
}
