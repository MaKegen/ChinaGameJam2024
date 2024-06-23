using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static event UnityAction OnTrapDetected;
    public static event Func<bool> OnTimeUp;
    //OnTrap和OnTime都只是激发事件触发的方法
    public static void OnTrap() => OnTrapDetected?.Invoke();
    public static void OnTime() => OnTimeUp?.Invoke(); 

}
