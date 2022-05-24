using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Setting : MonoBehaviour
{
    [SerializeField] private GameObject[] prifb;

    private const string NameKey = "SettingOSU";

    private GameObject install;
    private void Awake()
    {
        install = Instantiate(prifb[0], transform, false);
    }

    public void Click(int index)
    {
        Destroy(install);
        install = Instantiate(prifb[index], transform, false);
    }

    public static void Loading()
    {
        LoadingData.unloading += Unloading;
        var save = LoadingJS.OnLoadObject(NameKey, new SettingJS());
        Application.targetFrameRate = save.frame;
    }

    private static void Unloading()
    {
        LoadingJS.EXIT(NameKey, new SettingJS
        {
            frame = Application.targetFrameRate,
        });
    }

}

[System.Serializable]
public class SettingJS
{

    public int frame = 60;
    public float volume = 1f;
}


