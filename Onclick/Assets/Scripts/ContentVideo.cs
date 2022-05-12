using System.Collections;
using System;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class ContentVideo : MonoBehaviour
{
    public Text Name;
    private Animation anim;
    public int indexClip;

    private void Awake()
    {
        anim = GetComponent<Animation>();
        VideosContent.NullToPlayVideo += AnimStart;
    }
    public void SetVideo(string name)
    {
        int[] save = VideosContent.Saves[name];
        this.Name.text = name + $" \n<color=#00cc00>SIMPLE: {save[0]}</color>   <color=#ffd300>MEDLLE: {save[1]}</color>   <color=#ff0000>HARD: {save[2]}</color>";
    }
    public void AnimStart() => anim.Play();
    public void Click()
    {
        anim.Play();
        Menu.SetVideoMenu(indexClip);
    }
    private void OnDestroy() =>
        VideosContent.NullToPlayVideo -= AnimStart;
}
