using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSpectrum : SettingPart
{
    [SerializeField] private InputField ColorStart;
    [SerializeField] private InputField ColorEnd;
    [SerializeField] private Image ImageStart;
    [SerializeField] private Image ImageEnd;
    [SerializeField] private Slider SliderStart;
    [SerializeField] private Slider SliderEnd;

    private void Start()
    {
        ColorStart.text = "#" + ColorUtility.ToHtmlStringRGB(Setting.ColorStart);
        ColorEnd.text = "#" + ColorUtility.ToHtmlStringRGB(Setting.ColorEnd);
        ImageStart.color = Setting.ColorStart;
        ImageEnd.color = Setting.ColorEnd;
        SliderStart.value = Setting.ColorStart.a;
        SliderEnd.value = Setting.ColorEnd.a;
        SetAlphaStart();
        SetAlphaEnd();
    }

    public void SetColorStart()
    {
        if (ColorUtility.TryParseHtmlString(ColorStart.text, out Color newColor))
            ImageStart.color = newColor;
    }

    public void SetColorEnd()
    {
        if (ColorUtility.TryParseHtmlString(ColorEnd.text, out Color newColor))
            ImageEnd.color = newColor;
    }

    public void SetAlphaStart()
    {
        Color qew = ImageStart.color;
        ImageStart.color = new Color(qew.r, qew.g, qew.b, SliderStart.value);
    }

    public void SetAlphaEnd()
    {
        Color qew = ImageEnd.color;
        ImageEnd.color = new Color(qew.r, qew.g, qew.b, SliderEnd.value);
    }

    public void SaveColor()
    {
        Setting.ColorStart = ImageStart.color;
        Setting.ColorEnd = ImageEnd.color;
    }
}
