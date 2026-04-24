using UnityEngine;
using System;

public static class EventBus
{
    public static event Action OnSliding;

    public static void SendSlidingEvent()
    {
        OnSliding?.Invoke();
    }
}
