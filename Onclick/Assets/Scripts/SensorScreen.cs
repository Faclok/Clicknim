using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScreen : MonoBehaviour
{
    public Transform _left;
    public Transform _raigth;
    public Transform _up;
    public Transform _down;
    private void Awake()
    {
        SensorPoints.Down = _down;
        SensorPoints.Left = _left;
        SensorPoints.Rigth = _raigth;
        SensorPoints.Up = _up;
    }
}
public static class SensorPoints
{
    public static Transform Left;
    public static Transform Rigth;
    public static Transform Up;
    public static Transform Down;
}