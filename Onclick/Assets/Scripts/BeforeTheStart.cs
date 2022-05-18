using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BeforeTheStart : MonoBehaviour
{
    [SerializeField] public Text NameVideo;
    [SerializeField] public Text ScoresVideo;
    [SerializeField] public ControllGame ControllGame;
    [SerializeField] public Button[] levelingBut;
    [SerializeField] public Button StartBut;
    private Animation skip;
    public static leveling lvl;

    private void Awake()
    {
        skip = GetComponent<Animation>();
        NameVideo.text = Menu.SaveVideoClip.name;
        int[] scores = VideosContent.Saves[Menu.SaveVideoClip.name];
        ScoresVideo.text = $"{scores[0]}\n{scores[1]}\n{scores[2]}";
        InstallSetting();
    }

    private void InstallSetting()
    {
        if (SettingSpectrum.isSpectrum)
            Instantiate(PrifabUtility.Spectrum, ControllGame.Platform.transform, false);
    }

    public void ClickStart()
    {
        if (skip.isPlaying)
            return;
        skip.Play();
        ControllGame.StartGame();
    }
    public void ChancherHard(int value)
    {
        lvl = SetLevel(value);
        StartBut.image.color = levelingBut[value].image.color;
    }
    private leveling SetLevel(int indexHard)
    => indexHard switch
    {
        0 => leveling.Simple,
        1 => leveling.Midlle,
        2 => leveling.Hard,
        _ => leveling.Simple
    };
}
