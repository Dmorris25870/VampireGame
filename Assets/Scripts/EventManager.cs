using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    public delegate void QAbilityEvent();
    public static QAbilityEvent OnQAbility;
}
