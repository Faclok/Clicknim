using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shoumen : MonoBehaviour
{
    public RectTransform rectTransform;
    public int index;
    private Action<float[]> scaleSet;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        setScale(Setting.ScaleLoad);
    }

    private void setScale(ScaleLoad load)
    {
        switch (load)
        {
            case ScaleLoad.Fast: scaleSet += Scale; break;
            case ScaleLoad.Slow: scaleSet += ScaleTranslate; break;
        }

    }

    public void ScaleSound(float[] arr) { scaleSet?.Invoke(arr); }

    private void ScaleTranslate(float[] arr) =>
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, arr[index] * 1200f, 1), 0.5f);

    private void Scale(float[] arr) =>
        transform.localScale = new Vector3(1, arr[index] * (((float)Setting.Form) * 12f), 1);
}
