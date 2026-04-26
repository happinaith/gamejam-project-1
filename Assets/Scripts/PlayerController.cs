using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    [SerializeField] private SpriteRenderer sprite;

    private Rigidbody2D rigid;
    private float height;

    [field: SerializeField]
    public PlayerState state { get; private set; } = PlayerState.Running;
    public int healthPoints { get; private set; }

    public static PlayerController instance;

    void Start()
    {
        instance = this;
        rigid = GetComponent<Rigidbody2D>();
        //height = sprite.bounds.extents.y;
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
            SetPlayerState(PlayerState.Jumping);
            rigid.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            EventBus.SendJumpEvent();
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

    public void BounceLeft(InputAction.CallbackContext context)
    {
        if (context.performed && state == PlayerState.Running)
        {
            SetPlayerState(PlayerState.BouncingLeft);
            EventBus.SendBounceLeftEvent();
        }
    }

    public void BounceRight(InputAction.CallbackContext context)
    {
        if (context.performed && state == PlayerState.Running)
        {
            SetPlayerState(PlayerState.BoucningRight);
            EventBus.SendBounceRightEvent();
        }
    }

    public void SetPlayerState(PlayerState state)
    {
        this.state = state;
    }
}
