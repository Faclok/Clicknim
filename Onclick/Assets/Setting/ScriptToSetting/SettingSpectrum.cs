using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSpectrum : MonoBehaviour
{
    public static bool isSpectrum = true;
    public static int SizeSpectrums = 64;
    public static SpectrumForm Form = SpectrumForm.Spectrum;
    public static ScaleLoad ScaleLoad = ScaleLoad.Fast;
    private const string NameKey = "SettingSpectrum";

    public static void Loading()
    {
        SettingSpectrumJS save = LoadingJS.OnLoadObject(NameKey, new SettingSpectrumJS());
        isSpectrum = save.isSpectrum;
        SizeSpectrums = save.SizeSpectrums;
        Form = save.Form;
        ScaleLoad = save.ScaleLoad;
        LoadingData.unloading += Unloading;
    }
    public static void Unloading() =>
        LoadingJS.EXIT(NameKey, new SettingSpectrumJS
        {
            isSpectrum = isSpectrum,
            SizeSpectrums = SizeSpectrums,
            Form = Form,
            ScaleLoad = ScaleLoad
        });

}

[System.Serializable]
public class SettingSpectrumJS
{
    public bool isSpectrum = true;
    public int SizeSpectrums = 64;
    public SpectrumForm Form = SpectrumForm.Pitch;
    public ScaleLoad ScaleLoad = ScaleLoad.Fast;
}
