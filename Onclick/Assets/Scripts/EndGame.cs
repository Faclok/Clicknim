using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] public Text NameVideo;
    [SerializeField] public Text ScoreInfo;
    [SerializeField] public Button MenuClick;
    [SerializeField] public LoadingScene Loading;
    private Animation EndGameWindow;

    private void Awake()
    {
        EventManager.EndGameIsVideoPlay += EndVideo;
        EndGameWindow = GetComponent<Animation>();
        NameVideo.text = Menu.SaveVideoClip.name;
    }
    public void ClickMenu() => Loading._LoadingSceneStart();
    public void EndVideo() =>
        EndGameWindow.Play();
    public void ScoresText() =>
        ScoreInfo.text = $"score: {SpawnInGame.Score}";
    private void OnDestroy() =>
        EventManager.EndGameIsVideoPlay -= EndVideo;
}
