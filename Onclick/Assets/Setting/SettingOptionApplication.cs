using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System;

public class SettingOptionApplication : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] private Text TextFrameApp;
    [SerializeField] private Text InfoProduct;
    private void Start()
    {

        SetTextFrame(Application.targetFrameRate);
        SetTextInfo();
        slider.value = 0.22f;
    }
    private void SetTextInfo() => InfoProduct.text =
     String.Join(" \n ", new string[] {
         $"Version game: {Application.version}",
         $"Version Unity: {Application.unityVersion}",
         $"Company: {Application.companyName}" });
    public void Click() =>
          SetTextFrame(GetFrame(Application.targetFrameRate));

    private void SetTextFrame(int frame) => TextFrameApp.text = $"Frames in game: <color={GetColor(frame)}>{frame}</color>";

    private string GetColor(int frame) =>
     frame switch
     {
         30 => "red",
         60 => "yellow",
         90 => "#27DD20",
         120 => "cyan",
         _ => "black"
     };

    private int GetFrame(int realSize) =>
        Application.targetFrameRate = realSize == 120 ? 30 : realSize + 30;

    public void ChangerVolume() =>
        AudioListener.volume = slider.value;

}