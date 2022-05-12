using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderSpectrum : SettingPart
{
    [SerializeField] private Sprite Instaced;
    [SerializeField] private Sprite Deleted;
    [SerializeField] private Image Backgroung;

    private void Start() =>
    Backgroung.sprite = Setting.isSpectrum ? Instaced : Deleted;

    public void Click()
    {
        Setting.isSpectrum = !Setting.isSpectrum;
        Backgroung.sprite = Setting.isSpectrum ? Instaced : Deleted;
    }
}
