using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
#if UNITY_ANDROID
using Firebase.Analytics;
#endif

public class AnalyticsEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public void EventPurchase(Product product)
    {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        try
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventPurchase,
                    new Parameter(FirebaseAnalytics.ParameterItemName, product.receipt));
            FirebaseAnalytics.LogEvent("purchase_" + product.receipt);
        }
        catch { }
#endif

    }
    public void StartLvl()
    {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        try { FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart, new Parameter(FirebaseAnalytics.ParameterItemName, DataService.LastClickedPoint)); } catch { }
    
#endif
    }
    public void EndLvl()
    {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        try
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelEnd, new Parameter(FirebaseAnalytics.ParameterItemName, DataService.LastClickedPoint));
        }
        catch { }
#endif
    }
    public void FailedLvl()
    {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        try
        {
            FirebaseAnalytics.LogEvent("Level failed" + DataService.LastClickedPoint);
        }
        catch { }
#endif
    }
    public void BayItem(string id)
    {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        try
        {
            FirebaseAnalytics.LogEvent("Bay Item - " + id);
        }
        catch { }
#endif
    }
    public void UpgradeItem(string id)
    {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        try
        {
            FirebaseAnalytics.LogEvent("Upgrade Item - " + id);
        }
        catch { }
#endif
    }
}
