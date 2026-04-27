using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    [SerializeField] private SpriteRenderer sprite;

    private Rigidbody2D rigid;

    [field: SerializeField] public PlayerState state { get; private set; } = PlayerState.Running;
    [field: SerializeField] public int healthPoints { get; private set; }
    [field: SerializeField] public int healthPointsMax { get; private set; }
    [field: SerializeField] public int energyPoints { get; private set; }
    [field: SerializeField] public int energyPointsMax { get; private set; }

    public static PlayerController instance;

    void Awake() // Используем Awake для синглтона
    {
        instance = this;
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        // Обязательно подписываемся
        EventBus.OnPlayerAnimationOver += AnimationOver;
    }

    void OnDestroy() // КРИТИЧЕСКИ ВАЖНО: Отписываемся при удалении объекта!
    {
        EventBus.OnPlayerAnimationOver -= AnimationOver;
        if (instance == this) instance = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверка на null самого себя (безопасность для InputSystem)
        if (this == null) return;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (state == PlayerState.Jumping)
            {
                state = PlayerState.Running;
            }
        }
    }

    private void AnimationOver()
    {
        if (this == null) return;
        SetPlayerState(PlayerState.Running);
    }

    // Добавляем проверки if(this == null) во все методы, которые вызываются извне (Input/Events)
    public void Jump(InputAction.CallbackContext context)
    {
        if (this == null) return;
        if (context.performed && state == PlayerState.Running)
        {
            EventBus.SendJumpEvent();
            SetPlayerState(PlayerState.Jumping);
            if (rigid != null) rigid.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
    }

    public void Sliding(InputAction.CallbackContext context)
    {
        if (this == null) return;
        if (context.performed && state == PlayerState.Running)
        {
            EventBus.SendSlidingEvent();
            SetPlayerState(PlayerState.Sliding);
        }
    }

    public void Bounce(InputAction.CallbackContext context)
    {
        if (this == null) return;
        if (context.performed && state == PlayerState.Running)
        {
            EventBus.SendBounceEvent();
            SetPlayerState(PlayerState.Bouncing);
        }
    }

    public void SetPlayerState(PlayerState state)
    {
        if (this == null) return;
        this.state = state;
    }

    public void TakeDamage()
    {
        if (this == null) return;
        healthPoints -= 1;
        EventBus.SendPlayerDamageEvent();
        if (healthPoints <= 0)
        {
            EventBus.SendPlayerDeadEvent();
        }
    }

    public void GiveHealth()
    {
        if (this == null || healthPoints >= healthPointsMax) return;
        healthPoints += 1;
        EventBus.OnHealthPickUpEvent();
    }

    public void GiveEnergy()
    {
        if (this == null || energyPoints >= energyPointsMax) return;
        energyPoints += 1;
        EventBus.OnEnergyPickUpEvent();

        if (energyPoints >= energyPointsMax)
        {
            EventBus.SendPlayerWinEvent();
        }
    }

    // Чтобы не ругалось на TakeEnergy
    public void TakeEnergy()
    {
        if (this == null || energyPoints <= 0) return;
        energyPoints -= 1;
        EventBus.EnergyDeductedEvent();
    }
}
