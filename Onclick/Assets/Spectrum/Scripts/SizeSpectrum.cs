using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSpectrum : SettingPart
{
    private Text text;

    private void Awake() => text = GetComponentInChildren<Text>();

    public void Click()
    {
        Spectrum.SizeSpectrums = GetSize(Spectrum.SizeSpectrums);
        text.text = Spectrum.SizeSpectrums.ToString();
    }
    private int GetSize(int realSize)
    {
        realSize *= 2;
        if (realSize ==16384)
            return 64;
        return realSize;
    }

}
