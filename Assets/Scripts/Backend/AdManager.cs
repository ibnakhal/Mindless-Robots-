#if AD_ENABLED
/**
 * $File: AdManager.cs $
 * $Date: #CREATIONDATE# $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *	                 Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

/// <summary>
/// 
/// </summary>
public class AdManager 
    : MonoBehaviour 
{

    public void ShowRewardedAd()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = OnVideoComplete;
        Advertisement.Show("rewardedVideo", options);
    }

    private void OnVideoComplete(ShowResult result)

    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.Log("Failed");
                break;

            case ShowResult.Finished:
                Debug.Log("Finsihed");
                break;

            case ShowResult.Skipped:
                Debug.Log("Skipped");
                break;
        }
    }
}
#endif