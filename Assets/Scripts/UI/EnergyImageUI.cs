using UnityEngine;
using UnityEngine.UI;

public class EnergyImageUI : MonoBehaviour
{
    public Sprite fullEnergy, emptyEnergy;
    private Image image;

    void Awake() => image = GetComponent<Image>();

    public void SetEnergyImage(EnergyStatus status)
    {
        switch (status)
        {
            case EnergyStatus.fullEnergy:
                image.sprite = fullEnergy;
                break;
            case EnergyStatus.emptyEnergy:
                image.sprite = emptyEnergy;
                break;
        }
    }

    public enum EnergyStatus
    {
        emptyEnergy = 0,
        fullEnergy = 1
    }
}
