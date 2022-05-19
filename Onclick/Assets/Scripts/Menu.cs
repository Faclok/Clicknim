using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Video;

public class Menu : MonoBehaviour
{
    [SerializeField] public VideoPlayer PreviewVideo;
    [SerializeField] public NameVideoContent NameVideo;
    [SerializeField] public LoadingScene LoadingScene;
    public static VideoClip SaveVideoClip;
    public static Menu menu;

    private void Start()
    {
        menu = this;
    }


    public void ClickMenu()
    {
        if (PreviewVideo.clip == null)
        {
            VideosContent.OnNullToPlayVideo();
            return;
        }
        Destroy(PreviewVideo.gameObject);
        LoadingScene._LoadingSceneStart();
    }

    private bool VisibleSetting = false;
    public void ClickSetActive(Animation obj)
    {
        if (!obj.isPlaying)
        {
            obj.Play(VisibleSetting ? "SettingHide" : "SettingShow");
            VisibleSetting = !VisibleSetting;
        }
    }


    public static void SetVideoMenu(VideoClip clip)
    {
        menu.PreviewVideo.clip = clip;
        SaveVideoClip = clip;
        menu.NameVideo.StartNewText();
        menu.PreviewVideo.Play();
        menu.PreviewVideo.isLooping = true;
    }
}
public enum leveling
{
    Simple = 0,
    Midlle = 1,
    Hard = 2
}