using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[Serializable]
public class EventoEnteros : UnityEvent<float>{}
public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        if (current==null)
        {
            current = this;
        }else if (current != null)
        {
            Destroy(this);
        }
    }

    public EventoEnteros updateBulletsEvent = new EventoEnteros();
}
