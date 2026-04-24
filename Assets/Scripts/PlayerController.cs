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

    public PlayerState state = PlayerState.Running;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        height = sprite.bounds.extents.y;
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * (height + 0.1f), Color.red);
    }

    private bool IsGrounded()
    {
        var hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, height + 0.1f, LayerMask.GetMask("Ground"));

        return hit;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed && IsGrounded())
        {
            Debug.Log(context);
            rigid.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
    }

    public void Sliding(InputAction.CallbackContext context)
    {
        EventBus.SendSlidingEvent();
    }
}
