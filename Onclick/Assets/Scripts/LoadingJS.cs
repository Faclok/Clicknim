using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadingJS
{
    public static T OnLoadObject<T>(string name, T ElseReturnLoad)
    {
        
        string name_ = name.Replace(' ', '_');
        if (PlayerPrefs.HasKey(name_))
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(name_));
        else
            return ElseReturnLoad;
    }
    public static void EXIT<T>(string name, T save)
    {
        name = name.Replace(' ', '_');
        string JsonData = JsonUtility.ToJson(save, true);
        PlayerPrefs.SetString(name, JsonData);
    }
}