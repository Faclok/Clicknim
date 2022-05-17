using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingOptionGame : MonoBehaviour
{
    [SerializeField] Text TextSizeSpectrum;

    public void Click() =>
        SetTextSpectrum(ref GetSize(ref SettingSpectrum.SizeSpectrums));

    private void SetTextSpectrum(ref int size) => TextSizeSpectrum.text = size != 0 ? $"Size spectrum {size}" : $"<color=#ff0000>OFF</color>";

    private ref int GetSize(ref int realSize)
    {
        realSize = realSize == 0 ? 64 : realSize * 2;
        if (!(SettingSpectrum.isSpectrum = realSize != 16384))
            realSize = 0;
        return ref realSize;
    }



}
