using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PointMove : MonoBehaviour
{
    public Vector3 startV;
    public Vector3 endV;
    public float step;
    private float progress;
    public static Action<Vector3> MiddleSpawn;

    public void set_point(Vector3 value)
    {
        transform.localPosition = value;
        if (value == endV)
        {
            progress = 0f;
            MiddleSpawn?.Invoke(endV);
        }
        else progress += step; //Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (transform.localPosition != endV)
            set_point(Vector3.Lerp(startV, endV, progress));
    }
}
