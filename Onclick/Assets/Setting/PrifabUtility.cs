using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrifabUtility : MonoBehaviour
{
    [Header("Prifabs")]
    [SerializeField] private Spectrum spectrum;
    [SerializeField] private PointMove pointMove;
    [SerializeField] private Shoumen shoumen;
    [SerializeField] private OnClick OnClickPoint;
    [SerializeField] private ColorSetting colorSetting;

    public static PointMove PointMove;
    public static Spectrum Spectrum;
    public static Shoumen Shoumen;
    public static OnClick OnClick;
    public static ColorSetting ColorSetting;

    private const string NameKey = "PrifabsUtility";

    private static bool isLoad;
    private void Awake()
    {
        if (isLoad)
            return;

        Spectrum = this.spectrum;
        (PointMove = this.pointMove).GetComponent<Image>().color = save.pointMove;
        (Shoumen = this.shoumen).GetComponent<Image>().color = save.shoumen;
        (OnClick = this.OnClickPoint).GetComponent<Image>().color = save.onClick;
        ColorSetting = this.colorSetting;

        isLoad = true;
    }

    private static PrifabsSave save;

    public static void Loading()
    {
        save = LoadingJS.OnLoadObject(NameKey, new PrifabsSave());
        LoadingData.unloading += Unloading;
    }

    public static void Unloading() => LoadingJS.EXIT(NameKey, new PrifabsSave
    {
        pointMove = PointMove.GetComponent<Image>().color,
        shoumen = Shoumen.GetComponent<Image>().color,
        onClick = OnClick.GetComponent<Image>().color
    });
}

[System.Serializable]
public class PrifabsSave
{
    public Color pointMove = Color.cyan;
    public Color shoumen = Color.blue;
    public Color onClick = Color.magenta;

}
