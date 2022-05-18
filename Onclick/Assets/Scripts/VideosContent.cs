using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System;
using System.IO;

public class VideosContent : MonoBehaviour
{
    public static Dictionary<string, int[]> Saves = new Dictionary<string, int[]>();

    #region MonoBehaviour 

    public static event Action NullToPlayVideo;
    [SerializeField] public ContentVideo Prifab;
    [SerializeField] public PlatformGame platform;
    private Animation anim;
    private bool isVisibleTable = true;

    private void Awake()
    {
        this.anim = GetComponent<Animation>();
        this.InstantiateVideo();
    }

    public static void OnNullToPlayVideo() => NullToPlayVideo?.Invoke();

    private void InstantiateVideo()
    {

        for (int i = 0; i < Saves.Count; i++)
        {
            var install = Instantiate(Prifab, platform.transform, false);
            install.SetVideo(PrifabUtility.Videos[i]);
        }
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

    public static void Loading(VideoClip[] Videos)
    {
        LoadingData.unloading += Unloading;
        foreach (var item in Videos)
            Saves.Add(item.name, LoadingJS.OnLoadObject(item.name, new ObjToSave()).Scors);
    }

    public static void Unloading()
    {
        foreach (var item in Saves)
            LoadingJS.EXIT(item.Key, new ObjToSave { Scors = item.Value });
    }

    #endregion
}

[System.Serializable]
public class ObjToSave
{
    public int[] Scors = new int[3];
}
