using UnityEngine;
using UnityEngine.UI;

public class SliderSync : MonoBehaviour
{
    public enum VolumeType { Music, SFX }
    public VolumeType type;

    void Start()
    {
        Slider slider = GetComponent<Slider>();

        // Берем значение из SoundManager и ставим слайдеру
        if (SoundManager.Instance != null)
        {
            if (type == VolumeType.Music)
                slider.value = SoundManager.Instance.musicVal;
            else
                slider.value = SoundManager.Instance.sfxVal;
        }

        // Подписываем слайдер на метод SoundManager программно (на случай, если ссылка в UI отвалится)
        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    void OnSliderChanged(float value)
    {
        if (SoundManager.Instance == null) return;

        if (type == VolumeType.Music)
            SoundManager.Instance.SetMusicVolume(value);
        else
            SoundManager.Instance.SetSFXVolume(value);
    }
}
