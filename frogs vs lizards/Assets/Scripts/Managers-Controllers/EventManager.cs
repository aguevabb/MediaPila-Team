using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class evento : UnityEvent<int>{}
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

    public evento UpdateBulletsEvent = new evento();
}
