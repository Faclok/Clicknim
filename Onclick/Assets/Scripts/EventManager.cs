using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
    public static event Action ClickToPoint;
    public static event Action EndGameIsVideoPlay;
    
    public static void OnEndGameIsVideoPlay() => EndGameIsVideoPlay?.Invoke();
    public static void OnClickToPoint() => ClickToPoint?.Invoke();
}
