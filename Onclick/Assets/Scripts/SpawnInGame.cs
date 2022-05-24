using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnInGame : MonoBehaviour
{
    private float difficultyTime;
    private float realTime;
    private float hideTime = 0.9f;
    public static bool spawn;
    public static int PointsInstanste;
    public static int Score;
    private PointMove move;

    private void Awake()
    {
        Score = 0;
        spawn = true;
        difficultyTime = GetTimeOnLvl(BeforeTheStart.lvl);
        PointMove.MiddleSpawn += InstallPoint;
        move = Instantiate(PrifabUtility.PointMove.gameObject, transform, false).GetComponent<PointMove>();
        move.step = GetSpeedOnLvl(BeforeTheStart.lvl);
    }

    private float GetTimeOnLvl(leveling lvl)
    => lvl switch
    {
        leveling.Simple => 1.64f,
        leveling.Midlle => 1.02f,
        leveling.Hard => 0.64f,
        _ => 0
    };
    private float GetSpeedOnLvl(leveling lvl)
    => lvl switch
    {
        leveling.Simple => 0.03f,
        leveling.Midlle => 0.05f,
        leveling.Hard => 0.07f,
        _ => 0
    };

    private void FixedUpdate()
    {
        realTime += Time.deltaTime;
        if (realTime >= difficultyTime && spawn)
        {
            realTime = 0;
            move.endV = PointSpawn.GetVector3Point();
            move.startV = move.transform.localPosition;
        }
        else if (!spawn)
            Delete();
    }

    private void InstallPoint(Vector3 vector)
    {
        var script = Instantiate(PrifabUtility.OnClick.gameObject, transform, false).GetComponent<OnClick>();
        script.transform.localPosition = vector;
        script.Visible = hideTime;
        script.number.text = PointsInstanste.ToString();
        PointsInstanste++;
    }

    public void Delete()
    {
        if (PointsInstanste <= 0)
            Destroy(this);
    }

    private void OnDestroy()
    {
        var scoreOld = VideosContent.Saves[Menu.SaveVideoClip.name];
        if (scoreOld[(int)BeforeTheStart.lvl] < Score)
        {
            scoreOld[(int)BeforeTheStart.lvl] = Score;
            ControllGame.NewScore = true;
        }
        PointMove.MiddleSpawn -= InstallPoint;
        EventManager.OnEndGameIsVideoPlay();
    }
}
