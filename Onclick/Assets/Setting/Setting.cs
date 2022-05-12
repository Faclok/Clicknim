using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    #region  Options

    public static bool isSpectrum;
    public static int SizeSpectrums = 64;
    public static SpectrumForm Form;
    public static ScaleLoad ScaleLoad =ScaleLoad.Slow;
    public static Color ColorStart;
    public static Color ColorEnd;

    #endregion
    #region  MonoBehaviour

    [SerializeField] private SettingIcon[] SettingNames;
    [SerializeField] private PlatformGame platformInfo;
    [SerializeField] private PlatformGame platformIcon;
    private static GameObject[] Instances;
    private static Setting instance;

    private static void ClearList()
    {
        if (Instances != null)
            foreach (var item in Instances)
                Destroy(item);

    }

    public static void Set_indexHow(int index)
    {
        ClearList();
        Instances = new GameObject[instance.SettingNames[index].settingParts.Length];
        for (int i = 0; i < instance.SettingNames[index].settingParts.Length; i++)
            Instances[i] = Instantiate(instance.SettingNames[index].settingParts[i].gameObject, instance.platformInfo.transform, false);
    }

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < SettingNames.Length; i++)
        {
            SettingNames[i].index = i;
            Instantiate(SettingNames[i].gameObject, platformIcon.transform, false);
        }
    }

    #endregion
    #region  LoadData 

    private const string SettingFile = "SettingOsu";

    public static void Loading()
    {
        SaveSetting save = LoadingJS.OnLoadObject(SettingFile, new SaveSetting());
        {
            isSpectrum = save.Spectrum;
            ColorStart = save.ColorStart;
            ColorEnd = save.ColorEnd;
        }
        LoadingData.unloading += Unloading;
    }
    public static void Unloading()
    {
        LoadingJS.EXIT(SettingFile, new SaveSetting
        {
            Spectrum = isSpectrum,
            ColorStart = ColorStart,
            ColorEnd = ColorEnd
        });
    }
    #endregion
}
