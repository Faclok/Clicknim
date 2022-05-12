using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class Spectrum : SettingPart
{
    [SerializeField] public Shoumen Prifab;
    private RectTransform rect;
    private float[] spectrum = new float[Setting.SizeSpectrums];
    private Shoumen[] array = new Shoumen[Setting.SizeSpectrums];
    public static float[] Sounds;
    private Action<float[]> soundHz;
    private Action ArgsSpectr;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        Sounds = spectrum;
        if (Setting.Form == SpectrumForm.Pitch)
            ArgsSpectr += PitchFormat;
        else ArgsSpectr += SpectrumFormat;
        Install();
        StartCoroutine(Fade());
    }

    public void Install()
    {
        for (int i = 0; i < spectrum.Length; i++)
        {
            array[i] = Instantiate(Prifab.gameObject, transform, false).GetComponent<Shoumen>();
            array[i].index = i;
            soundHz += array[i].ScaleSound;
        };
    }

    private void LateUpdate() =>
        ArgsSpectr?.Invoke();

    private void SpectrumFormat() => AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

    private void PitchFormat() => AudioListener.GetOutputData(spectrum, 0);

    IEnumerator Fade()
    {
        for (; ; )
        {
            soundHz?.Invoke(spectrum);
            yield return new WaitForSeconds(.04f);
        }
    }


}
public enum SpectrumForm
{
    Spectrum = 100,
    Pitch = 1000
}

public enum ScaleLoad
{
    Fast,
    Slow
}
