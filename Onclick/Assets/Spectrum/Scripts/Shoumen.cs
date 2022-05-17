using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Shoumen : MonoBehaviour
{
    public int index;
    private event Action<float[]> scaleSet;
    private float SizeScale;

    private void Awake()
    {
        SizeScale = (float)SettingSpectrum.Form;
        setScale(SettingSpectrum.ScaleLoad);
    }

    private void setScale(ScaleLoad load)
    {
        switch (load)
        {
            case ScaleLoad.Fast: scaleSet += Scale; break;
            case ScaleLoad.Slow: scaleSet += ScaleTranslate; break;
        }
    }

    public void ScaleSound(float[] arr) =>
        scaleSet?.Invoke(arr);

    private void ScaleTranslate(float[] arr) =>
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, arr[index] * SizeScale * 12f, 1), 0.5f);

    private void Scale(float[] arr) =>
        transform.localScale = new Vector3(1, arr[index] * SizeScale * 12f, 1);

}
