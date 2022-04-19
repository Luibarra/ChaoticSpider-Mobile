using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    //android: 4687138;
    //apple: 4687139;
    string gameId = "your_id";
    bool testMode = false;

#if UNITY_IOS
        private string gameId = "4687139";
#elif UNITY_ANDROID
        private string gameId = "4687138";
#endif

    void Start()
    {
        // Initialize the Ads service:
        Advertisement.Initialize(gameId);
        //Advertisement.Initialize(gameId, testMode);
    }

    public void ResilientSpider()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show("ResilientSpider");
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
        //Time.timeScale = 0f;
    }

}