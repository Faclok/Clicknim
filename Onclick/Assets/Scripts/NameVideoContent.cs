using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameVideoContent : MonoBehaviour
{
    private Text nameVideo;
    private Animation anim;

    private void Awake()
    {
        nameVideo = GetComponent<Text>();
        anim = GetComponent<Animation>();
    }
    public void StartNewText() => anim.Play("ScoreMoveMenuStart");
    public void SetText()
    {
        nameVideo.text = Menu.SaveVideoClip.name;
        anim.Play("ScoreMoveMenuEnd");
    }
}
