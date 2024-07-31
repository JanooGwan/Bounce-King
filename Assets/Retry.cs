using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class Retry : MonoBehaviour
{
    private InterstitialAd interstitial;
    public Canvas myCanvas;

    private void RequestInterstitial()
    {
    #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-4148505704696110/1851282886";
    #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
    #else
        string adUnitId = "unexpected_platform";
    #endif

    // Initialize an InterstitialAd.
    this.interstitial = new InterstitialAd(adUnitId);
    // Called when the ad is closed.
    this.interstitial.OnAdClosed += HandleOnAdClosed;
    // Create an empty ad request.
    AdRequest request = new AdRequest.Builder().Build();
    // Load the interstitial with the request.
    this.interstitial.LoadAd(request);
    }

    public void ReplayGame()
    {
        RequestInterstitial();
        StartCoroutine(showInterstitial());

        IEnumerator showInterstitial()
        {
            while(!this.interstitial.IsLoaded())
            {
                Debug.Log("hello");
                yield return new WaitForSeconds(0.2f);
            }
            myCanvas.sortingOrder=-1;
            this.interstitial.Show();
        }

        
    }

    public void HandleOnAdClosed(object sender, System.EventArgs args)
    {
        SceneManager.LoadScene("InGame");
    }
}
