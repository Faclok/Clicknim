using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PrifabUtility : MonoBehaviour
{
    [Header("Prifabs")]
    [SerializeField] private Spectrum spectrum;
    [SerializeField] private PointMove pointMove;
    [SerializeField] private Shoumen shoumen;
    [SerializeField] private OnClick OnClickPoint;
    [SerializeField] private VideoClip[] videos;

    public static PointMove PointMove;
    public static Spectrum Spectrum;
    public static Shoumen Shoumen;
    public static OnClick OnClick;
    public static VideoClip[] Videos;

    private const string NameKey = "PrifabsUtility";

    private static bool isLoad;
    private void Awake()
    {
        if (isLoad)
            return;

        Spectrum = this.spectrum;
        PointMove = this.pointMove;
        Shoumen = this.shoumen;
        OnClick = this.OnClickPoint;
        Videos = this.videos;

        isLoad = true;
    }


    public static void Loading()
    {
        LoadingData.unloading += Unloading;
        var save = LoadingJS.OnLoadObject(NameKey, new PrifabsSave());
        PointMove.GetComponent<Image>().color = save.pointMove;
        Shoumen.GetComponent<Image>().color = save.shoumen;
        OnClick.GetComponent<Image>().color = save.onClick;
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
