using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    [SerializeField] private SpriteRenderer sprite;

    private Rigidbody2D rigid;

    [field: SerializeField]
    public PlayerState state { get; private set; } = PlayerState.Running;
    [field: SerializeField]
    public int healthPoints { get; private set; }
    [field: SerializeField]
    public int healthPointsMax { get; private set; }
    [field: SerializeField]
    public int energyPoints { get; private set; }
    [field: SerializeField]
    public int energyPointsMax { get; private set; }

    public static PlayerController instance;

    void Start()
    {
        instance = this;
        rigid = GetComponent<Rigidbody2D>();
        EventBus.OnPlayerAnimationOver += AnimationOver;
    }

    void Update()
    {
        //Debug.DrawRay(transform.position, Vector2.down * (height + 0.1f), Color.red);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        SetPlayerState(PlayerState.Running);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && state == PlayerState.Running)
        {
            EventBus.SendJumpEvent();
            SetPlayerState(PlayerState.Jumping);
            rigid.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
    }

    public void Sliding(InputAction.CallbackContext context)
    {
        if (context.performed && state == PlayerState.Running)
        {
            EventBus.SendSlidingEvent();
            SetPlayerState(PlayerState.Sliding);
        }
    }

    public void Bounce(InputAction.CallbackContext context)
    {
        if (context.performed && state == PlayerState.Running)
        {
            EventBus.SendBounceEvent();
            SetPlayerState(PlayerState.Bouncing);
        }
    }

    public void SetPlayerState(PlayerState state)
    {
        this.state = state;
    }

    public void TakeDamage()
    {
        healthPoints -= 1;
        EventBus.SendPlayerDamageEvent();
        if (healthPoints <= 0)
        {
            EventBus.SendPlayerDeadEvent();
            return;
        }
    }

    public void GiveHealth()
    {
        if (healthPoints == healthPointsMax) return;

        healthPoints += 1;
        EventBus.OnHealthPickUpEvent();
    }

    public void GiveEnergy()
    {
        if (energyPoints == energyPointsMax) return;
        energyPoints += 1;
        EventBus.OnEnergyPickUpEvent();
    }
}
