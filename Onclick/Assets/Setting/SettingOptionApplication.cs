using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SettingOptionApplication : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] private Text TextFrameApp;
    private void Start()
    {
        Application.targetFrameRate = 30;
        SetTextFrame(Application.targetFrameRate);
    }

    public void Click() =>
          SetTextFrame(GetFrame(Application.targetFrameRate));

    private void SetTextFrame(int frame) => TextFrameApp.text = $"Frame game {frame}";

    private int GetFrame(int realSize) =>
        Application.targetFrameRate = realSize == 120 ? 30 : realSize + 30;

    public void ChangerVolume() =>
        AudioListener.volume = slider.value;
}