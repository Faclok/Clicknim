using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawn : MonoBehaviour
{

    public static GameObject RandomSpawning(GameObject prifab, Transform backgroung)
    {
        Vector3 vectorRandom = GetVector3Point();
        GameObject point = Instantiate(prifab, backgroung);
        point.transform.localPosition = vectorRandom;
        return point;
    }

    public static GameObject[] Instantiates(GameObject[] gameObjects, Transform backgroung)
    {
        GameObject[] arr = new GameObject[gameObjects.Length];
        for (int i = 0; i < gameObjects.Length; i++)
            arr[i] = Instantiate(gameObjects[i], backgroung, false);
        return arr;
        
    }

    public static Vector3 GetVector3Point()
    {
        return new Vector3(Random.Range(SensorPoints.Left.localPosition.x + 150f, SensorPoints.Rigth.localPosition.x - 150f),
          Random.Range(SensorPoints.Down.localPosition.y + 150f, SensorPoints.Up.localPosition.y - 150f), 0);
    }
}
