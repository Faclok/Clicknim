using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingIcon : MonoBehaviour
{
    [SerializeField] public SettingPart[] settingParts;
    public int index;

    public void Click() => Setting.Set_indexHow(index);
}
