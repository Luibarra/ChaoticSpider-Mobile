using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    //android: 4687138;
    //apple: 4687139;
    string gameId = "4687138";
    //bool testMode = true;

/*#if UNITY_IOS
    private string gameId = "4687139";
#endif*/

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
            if(gameId == "4687138")
                Advertisement.Show("ResilientSpider_");
            else
                Advertisement.Show("Rewarded_iOS");
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
            //Debug.Log("Oh no! A nut!");
        }
        //Time.timeScale = 0f;
    }

}