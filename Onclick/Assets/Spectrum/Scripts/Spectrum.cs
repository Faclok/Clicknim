using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class Spectrum : SettingPart
{
    [SerializeField] public FFTWindow window;
    [SerializeField] public Shoumen Prifab;
    private RectTransform rect;
    private float[] spectrum = new float[SizeSpectrums];
    public static float[] Sounds;
    private Shoumen[] array = new Shoumen[SizeSpectrums];
    public static int SizeSpectrums = 512;
    private Action<float[]> soundHz;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        Sounds = spectrum;
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

    private void LateUpdate()
    {

        AudioListener.GetSpectrumData(spectrum, 0, window);
    }

    IEnumerator Fade()
    {
        for (; ; )
        {
            // AudioListener.GetOutputData(spectrum, 0);
            soundHz?.Invoke(spectrum);
            yield return new WaitForSeconds(.04f);
        }
    }
    private void ScaleTranslate(ref int i)
    {
        array[i].transform.localScale = Vector3.Lerp(array[i].transform.localScale, new Vector3(1, spectrum[i] * 1200f, 1), 0.5f);
    }
    private void Scale(ref int i)
    {
        array[i].transform.localScale = new Vector3(1, spectrum[i] * 1200f, 1);
    }
}
