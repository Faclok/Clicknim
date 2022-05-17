using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spectrum : MonoBehaviour
{
    private float[] spectrum = new float[SettingSpectrum.SizeSpectrums]; //value sounds
    private Shoumen[] array = new Shoumen[SettingSpectrum.SizeSpectrums];//Lines install
    private event Action<float[]> soundHz;                               //Подписчики - Lines
    private event Action ArgsSpectr;                                     //Format Spectrum

    private void Awake()
    {
        FormatSpectrum(ref SettingSpectrum.Form);
        Install();
        StartCoroutine(Fade());
    }

    //подписка на Format Spectrum
    private void FormatSpectrum(ref SpectrumForm form)
    {
        switch (form)
        {
            case SpectrumForm.Spectrum: ArgsSpectr += SpectrumFormat; break;
            case SpectrumForm.Pitch: ArgsSpectr += PitchFormat; break;
        }
    }

    //Install Lines
    public void Install()
    {
        for (int i = 0; i < spectrum.Length; i++)
        {
            array[i] = Instantiate(PrifabUtility.Shoumen.gameObject, transform, false).GetComponent<Shoumen>();
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
    Pitch = 10
}

public enum ScaleLoad
{
    Fast,
    Slow
}
