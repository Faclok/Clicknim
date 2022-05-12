using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Audio;

public class ControllGame : MonoBehaviour
{
    [SerializeField] public Text TextTime;
    [SerializeField] public PlatformGame Platform;
    [SerializeField] public VideoPlayer VideoPlayer;
    [SerializeField] public OnClick PrifabPoint;
    [SerializeField] public Image PlatformScore;
    public static bool NewScore;
    private Animation AnimScorePoint;
    private Text TextScore;
    private event Action Tick;

    private void Awake()
    {
        NewScore = false;
        EventManager.EndGameIsVideoPlay += EndGame;
        EventManager.ClickToPoint += OnTextScore;
        VideoPlayer.clip = Menu.SaveVideoClip;
        AnimScorePoint = PlatformScore.GetComponent<Animation>();
        TextScore = PlatformScore.GetComponentInChildren<Text>();
    }

    private void FixedUpdate() =>
        Tick?.Invoke();

    private void isVideoPlay() => SpawnInGame.spawn = VideoPlayer.isPlaying;

    private void TickVideoText() =>
        TextTime.text = $"{Mathf.Round((float)(VideoPlayer.length - VideoPlayer.time))}";

    public void StartGame()
    {
        VideoPlayer.Play();
        Tick += isVideoPlay;
        Tick += TickVideoText;
        SpawnInGame times = Platform.gameObject.AddComponent<SpawnInGame>();
        times.prifabPoint = PrifabPoint;
        if (Setting.isSpectrum)
            times.sounds = Spectrum.Sounds;
        else
        {
            times.sounds = spectrumDemo = new float[64];
            Tick += GetHz;
        }
    }

    private float[] spectrumDemo;

    private void GetHz()
    {
        AudioListener.GetSpectrumData(spectrumDemo, 0, FFTWindow.Rectangular);
    }

    public void OnTextScore()
    {
        TextScore.text = $"{SpawnInGame.Score}";
        AnimScorePoint.Play();
    }

    private void EndGame()
    {
        Tick -= isVideoPlay;
        Tick -= TickVideoText;
        Tick -= GetHz;
    }

    private void OnDestroy() =>
        EventManager.ClickToPoint -= OnTextScore;
}
