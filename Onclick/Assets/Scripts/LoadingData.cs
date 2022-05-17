using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LoadingData : MonoBehaviour
{
    private static bool isLoadData;
    public static event Action unloading;

    private void Awake()
    {
        if (isLoadData)
            return;

        Application.quitting += Quit;

        PrifabUtility.Loading();
        SettingSpectrum.Loading();
        VideosContent.Loading();
        Application.targetFrameRate = 65;

        isLoadData = true;
    }
    private static void Quit() =>
        unloading?.Invoke();

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) Quit();
    }
}
