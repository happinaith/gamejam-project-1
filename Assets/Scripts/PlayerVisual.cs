using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private void Start()
    {
        EventBus.OnSliding += SlidingEffect;
    }

    private void SlidingEffect()
    {
        var component = gameObject.GetComponent<SpriteRenderer>();

        component.color = Color.chartreuse;
    }

    private void Update()
    {

    }
}