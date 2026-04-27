using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private SpriteRenderer component;
    private Animator _animator;

    private static readonly int SlideTrigger = Animator.StringToHash("DoSlide");
    private static readonly int JumpTrigger = Animator.StringToHash("DoJump");
    private static readonly int BounceTrigger = Animator.StringToHash("DoBounce");

    private void Start()
    {
        EventBus.OnSliding += SlidingEffect;
        EventBus.OnBounce += BounceEffect;
        EventBus.OnJumping += JumpingEffect;

        component = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        EventBus.OnSliding -= SlidingEffect;
        EventBus.OnBounce -= BounceEffect;
        EventBus.OnJumping -= JumpingEffect;
    }

    private void JumpingEffect()
    {
        if (PlayerController.instance.state != PlayerState.Running) return;
        _animator.SetTrigger(JumpTrigger);
    }

    private void BounceEffect()
    {
        if (PlayerController.instance.state != PlayerState.Running) return;
        _animator.SetTrigger(BounceTrigger);
    }

    private void SlidingEffect()
    {
        if (PlayerController.instance.state != PlayerState.Running) return;
        _animator.SetTrigger(SlideTrigger);
    }

    private void AnimationOver()
    {
        EventBus.SendPlayerAnimationOverEvent();
    }

    private void Update()
    {

    }
}