using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingOptionGame : MonoBehaviour
{
    [SerializeField] Text TextSizeSpectrum;

    public void Awake()
    {
        SetTextSpectrum(SettingSpectrum.SizeSpectrums);
    }

    public void Click() =>
        SetTextSpectrum(GetSize(ref SettingSpectrum.SizeSpectrums));

    private void SetTextSpectrum(int size) => TextSizeSpectrum.text = size != 0 ? $"Size spectrum {size}" : $"<color=#ff0000>OFF</color>";

    private int GetSize(ref int realSize)
    {
        realSize = realSize == 0 ? 64 : realSize * 2;
        if (!(SettingSpectrum.isSpectrum = realSize != 16384))
            realSize = 0;
        return realSize;
    }
}
