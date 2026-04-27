using UnityEngine;
using UnityEngine.UI;

public class HealthImageUI : MonoBehaviour
{
    public Sprite fullHealth, emptyHealth;
    private Image image;

    void Awake() => image = GetComponent<Image>();

    public void SetHealthImage(HealthStatus status)
    {
        switch (status)
        {
            case HealthStatus.fullHealth:
                image.sprite = fullHealth;
                break;
            case HealthStatus.emptyHealth:
                image.sprite = emptyHealth;
                break;
        }
    }

    public enum HealthStatus
    {
        emptyHealth = 0,
        fullHealth = 1
    }
}
