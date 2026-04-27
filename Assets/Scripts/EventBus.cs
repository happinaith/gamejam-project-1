using UnityEngine;
using System;

public static class EventBus
{
    public static event Action OnSliding;
    public static event Action OnJumping;
    public static event Action OnBounce;

    public static event Action OnPlayerAnimationOver;

    public static event Action OnHealthPickUp;
    public static event Action OnEnergyPickUp;
    public static event Action OnEnergyDeducted;

    public static event Action OnPlayerDamage;
    public static event Action OnPlayerDead;
    public static event Action OnPlayerWin;


    public static void SendSlidingEvent()
    {
        OnSliding?.Invoke();
    }

    public static void SendJumpEvent()
    { 
        OnJumping?.Invoke(); 
    }

    public static void SendBounceEvent()
    {
        OnBounce?.Invoke();
    }

    public static void SendPlayerAnimationOverEvent()
    {
        OnPlayerAnimationOver?.Invoke();
    }

    public static void OnHealthPickUpEvent()
    {
        OnHealthPickUp?.Invoke();
    }

    public static void OnEnergyPickUpEvent()
    {
        OnEnergyPickUp?.Invoke();
    }

    public static void EnergyDeductedEvent()
    {
        OnEnergyDeducted?.Invoke();
    }

    public static void SendPlayerDeadEvent()
    {
        OnPlayerDead?.Invoke();
    }

    public static void SendPlayerDamageEvent()
    {
        OnPlayerDamage?.Invoke();
    }
    public static void SendPlayerWinEvent()
    {
        OnPlayerWin?.Invoke();
    }

}
