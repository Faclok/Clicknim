using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class SettingOptionGame : MonoBehaviour
{
    [SerializeField] Text TextSizeSpectrum;
    [SerializeField] Dropdown ImagesDrow;
    [SerializeField] Dropdown EnumTypes;
    [SerializeField] Dropdown EnumType;
    [SerializeField] InputField TextRGBA;
    [SerializeField] Image ColorImage;
    private Image[] ImagesElement;
    private static readonly string[] NameEnums = { nameof(SpectrumForm), nameof(ScaleLoad) };
    private static readonly SpectrumForm[] spectrumForms = { SpectrumForm.Pitch, SpectrumForm.Spectrum };
    private static readonly ScaleLoad[] scaleLoads = { ScaleLoad.Fast, ScaleLoad.Slow };
    public void Awake()
    {
        SetTextSpectrum(SettingSpectrum.SizeSpectrums);
        ClearAndSetupDrows();
        ChangerImage();
        ChangerTypesEnum();
    }

    private void ClearAndSetupDrows()
    {
        ClearAndSetupDrowImage();
        ClearAndSetupDrowEnum();
    }
    private void ClearAndSetupDrowImage()
    {
        ImagesDrow.ClearOptions();
        ImagesElement = new MonoBehaviour[] { PrifabUtility.Shoumen, PrifabUtility.PointMove, PrifabUtility.OnClick }.Select(o => o.GetComponent<Image>()).ToArray();
        ImagesDrow.options.AddRange(ImagesElement.Select(o => new Dropdown.OptionData(o.name)).ToArray());
    }
    private void ClearAndSetupDrowEnum()
    {
        EnumTypes.ClearOptions();
        EnumTypes.options.AddRange(NameEnums.Select(o => new Dropdown.OptionData(o)).ToArray());
        ChangerTypesEnum();
    }

    public void ChangerTypesEnum()
    {
        EnumType.ClearOptions();
        EnumType.AddOptions(GetOptionDatasList(GetOptionDatas(EnumTypes.value),
         new Enum[] { SettingSpectrum.Form, SettingSpectrum.ScaleLoad }[EnumTypes.value]));
        EnumType.value = valueIndex;
    }
    private Enum[] GetOptionDatas(int index) =>
    index switch
    {
        0 => spectrumForms.Select(o => (Enum)o).ToArray(),
        1 => scaleLoads.Select(o => (Enum)o).ToArray(),
        _ => throw new IndexOutOfRangeException()
    };

    public void ChangerTypeEnum()
    {
        switch (EnumTypes.value)
        {
            case 0: SettingSpectrum.Form = spectrumForms[EnumType.value]; break;
            case 1: SettingSpectrum.ScaleLoad = scaleLoads[EnumType.value]; break;
        }
    }
    private int valueIndex;
    private List<Dropdown.OptionData> GetOptionDatasList(Enum[] enums, Enum realtime)
    {
        for (int i = 0; i < enums.Length; i++)
            if (enums[i].ToString() == realtime.ToString())
                valueIndex = i;
        return enums.Select(o => new Dropdown.OptionData(o.ToString())).ToList();
    }

    public void ChangerImage()
    {
        TextRGBA.text = "#" + ColorUtility.ToHtmlStringRGBA(ImagesElement[ImagesDrow.value].color);
        ColorImage.sprite = ImagesElement[ImagesDrow.value].sprite;
    }

    public void ChangerColor()
    {
        if (ColorUtility.TryParseHtmlString(TextRGBA.text, out Color newColor))
        {
            ColorImage.color = newColor;
            ImagesElement[ImagesDrow.value].color = newColor;
        }
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
