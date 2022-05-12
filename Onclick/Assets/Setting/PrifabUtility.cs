using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrifabUtility : MonoBehaviour
{
    [Header("Prifabs")]
    [SerializeField] private Spectrum spectrum;
    [SerializeField] private PointMove pointMove;
    public static PointMove PointMove;
    public static Spectrum Spectrum;
    private bool isLoad;
    private void Awake()
    {
        if (isLoad)
            return;

        Spectrum = spectrum;
        PointMove = pointMove;

        isLoad = true;
    }
}
