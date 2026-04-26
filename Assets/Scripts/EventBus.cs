using UnityEngine;
using System;

public static class EventBus
{
    public static event Action OnSliding;
    public static event Action OnJumping;
    public static event Action OnBounceLeft;
    public static event Action OnBounceRight;

    public static event Action OnPlayerAnimationOver;

    public static void SendSlidingEvent()
    {
        OnSliding?.Invoke();
    }

    public static void SendJumpEvent()
    { 
        OnJumping?.Invoke(); 
    }

    public static void SendBounceLeftEvent()
    {
        OnBounceLeft?.Invoke();
    }

    public static void SendBounceRightEvent()
    {
        OnBounceRight?.Invoke();
    }

    public static void SendPlayerAnimationOverEvent()
    {
        OnPlayerAnimationOver?.Invoke();
    }

}
