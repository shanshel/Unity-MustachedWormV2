﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppsFlyerObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /* Mandatory - set your AppsFlyer’s Developer key. */
        AppsFlyer.setAppsFlyerKey("zcKrZYJWnrWWctCxcLNnyT");
        /* For detailed logging */
        /* AppsFlyer.setIsDebug (true); */
        #if UNITY_IOS
                /* Mandatory - set your apple app ID
                NOTE: You should enter the number only and not the "ID" prefix */
                AppsFlyer.setAppID("1481816891");
                AppsFlyer.getConversionData();
                AppsFlyer.trackAppLaunch();
        #elif UNITY_ANDROID
             /* For getting the conversion data in Android, you need to add the "AppsFlyerTrackerCallbacks" listener.*/
             AppsFlyer.init ("YOUR_APPSFLYER_DEV_KEY","AppsFlyerTrackerCallbacks");
        #endif
    }


}
