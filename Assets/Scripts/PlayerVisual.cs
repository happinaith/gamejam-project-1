using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private SpriteRenderer component;
    private Animator _animator;

    private static readonly int SlideTrigger = Animator.StringToHash("DoSlide");

    private void Start()
    {
        EventBus.OnSliding += SlidingEffect;
        EventBus.OnBounceLeft += BounceLeftEffect;
        EventBus.OnBounceRight += BounceRightEffect;

        component = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void BounceRightEffect()
    {
        component.color = Color.red;
    }

    private void BounceLeftEffect()
    {
        component.color = Color.green;
    }

    private void SlidingEffect()
    {
        if (PlayerController.instance.state != PlayerState.Running) return;
        _animator.SetTrigger(SlideTrigger);
        component.color = Color.chartreuse;
    }

    private void AnimationOver()
    {
        EventBus.SendPlayerAnimationOverEvent();
    }

    private void Update()
    {

    }
}