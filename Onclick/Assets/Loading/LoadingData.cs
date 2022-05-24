using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadingData : MonoBehaviour
{
    public static event Action unloading;
    public static bool Load = false;

    private void Start()
    {
        if (Load)
            return;

        Application.quitting += Quit;

        VideosContent.Loading(PrifabUtility.Videos);
        PrifabUtility.Loading();
        SceneManager.LoadScene(1);
        Setting.Loading();
        SettingSpectrum.Loading();

        Load = true;
    }
    private static void Quit() =>
        unloading?.Invoke();

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) Quit();
    }
}
