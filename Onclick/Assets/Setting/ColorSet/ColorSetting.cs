using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSetting : MonoBehaviour
{
    [SerializeField] private InputField TextRGBA;
    [SerializeField] private Image imageDisplay;
    [SerializeField] private Text nameColor;

    public void SetColor()
    {
        if (ColorUtility.TryParseHtmlString(TextRGBA.text, out Color newColor))
        {
            imageDisplay.color = newColor;
        }
    }

    public void SetImage(Image newImage, string name)
    {
        imageDisplay.sprite = newImage.sprite;
        imageDisplay.color = newImage.color;
        nameColor.text = name;
        TextRGBA.text = "#" + ColorUtility.ToHtmlStringRGBA(newImage.color);
    }
}
