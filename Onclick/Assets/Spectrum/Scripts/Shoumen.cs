using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoumen : MonoBehaviour
{
    public RectTransform rectTransform;
    public int index;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void ScaleSound(float[] arr)
    {
        transform.localScale = new Vector3(1, arr[index] * 1201f, 1);
    }
}
