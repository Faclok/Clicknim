using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System;

public class VideosContent : MonoBehaviour
{
    public static Dictionary<string, int[]> Saves = new Dictionary<string, int[]>();

    #region MonoBehaviour 

    public static event Action NullToPlayVideo;
    [SerializeField] public ContentVideo Prifab;
    [SerializeField] public PlatformGame platform;
    [SerializeField] public VideoClip[] Clips;
    public static VideoClip[] GameVideos;
    private Animation anim;
    private bool isVisibleTable = true;
    private static bool isload;

    private void Awake()
    {
        this.anim = GetComponent<Animation>();
        this.InstantiateVideo();
    }

    public static void OnNullToPlayVideo() => NullToPlayVideo?.Invoke();

    private void InstantiateVideo()
    {
        GameVideos = Clips;
        for (int i = 0; i < Clips.Length; i++)
        {
            if (!isload)
                Saves.Add(Clips[i].name, LoadingJS.OnLoadObject(Clips[i].name, new ObjToSave()).Scors);
            Prifab.SetVideo(Clips[i].name);
            Prifab.indexClip = i;
            Instantiate(Prifab.gameObject, platform.transform, false);
        }
        isload = true;
    }

    public void MoveTable()
    {
        if (anim.isPlaying)
            return;
        anim.Play(isVisibleTable ? "HideVideos" : "ShowVideos");
    }

    public void EndMoveTable() => isVisibleTable = !isVisibleTable;

    #endregion
    #region LoadData 

    public static void Loading()
    {
        LoadingData.unloading += Unloading;
    }

    public static void Unloading()
    {
        foreach (var item in Saves)
            LoadingJS.EXIT(item.Key, new ObjToSave { Scors = item.Value });
    }

    #endregion
}
