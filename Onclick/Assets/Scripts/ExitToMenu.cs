using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExitToMenu : MonoBehaviour
{
    [SerializeField] public LoadingScene Loading;
    public static bool VisibleMenuClick = true;
    private Animation anim;

    void Awake()
    {
        anim = GetComponent<Animation>();
        EventManager.ClickToPoint += ClickVisibleOff;
    }
    public void IsVisible() => VisibleMenuClick = !VisibleMenuClick;
    public void ClickMenu()
    {
        if (VisibleMenuClick)
            Loading._LoadingSceneStart();
        else
        {
            anim.Play("MenuButtonShow");
            VisibleMenuClick = true;
        }
    }
    private void ClickVisibleOff()
    {
        if (VisibleMenuClick)
            anim.Play("MenuButtonHide");
    }
    private void OnDestroy() =>
       EventManager.ClickToPoint -= ClickVisibleOff;

}
