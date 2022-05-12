using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadingData : MonoBehaviour
{
    private static bool isLoadData;
    public static event Action unloading;

    private void Awake()
    {
        if (isLoadData)
            return;

        Application.quitting += Quit;

        Setting.Loading();
        VideosContent.Loading();

        isLoadData = true;
    }
    private static void Quit() =>
        unloading?.Invoke();

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) Quit();
    }
}