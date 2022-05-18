using System.Collections;
using System;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class ContentVideo : MonoBehaviour
{
    public Text Name;
    private Animation anim;
    private VideoClip Clip;

    private void Awake()
    {
        anim = GetComponent<Animation>();
        VideosContent.NullToPlayVideo += AnimStart;
    }
    public void SetVideo(VideoClip clip)
    {
        Clip = clip;
        int[] save = VideosContent.Saves[clip.name];
        this.Name.text = clip.name + $" \n<color=#00cc00>SIMPLE: {save[0]}</color>   <color=#ffd300>MEDLLE: {save[1]}</color>   <color=#ff0000>HARD: {save[2]}</color>";
    }
    public void AnimStart() => anim.Play();
    public void Click()
    {
        anim.Play();
        Menu.SetVideoMenu(Clip);
    }
    private void OnDestroy() =>
        VideosContent.NullToPlayVideo -= AnimStart;
}
