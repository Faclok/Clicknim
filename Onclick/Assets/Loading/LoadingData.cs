using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadingData : MonoBehaviour
{
    public static event Action unloading;

    private void Start()
    {

        Application.quitting += Quit;

        VideosContent.Loading(PrifabUtility.Videos);
        PrifabUtility.Loading();
Application.targetFrameRate =90;
        SceneManager.LoadScene(1);
    }
    private static void Quit() =>
        unloading?.Invoke();

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) Quit();
    }
}
