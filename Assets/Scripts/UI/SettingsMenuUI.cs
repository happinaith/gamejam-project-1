using UnityEngine;
using UnityEngine.UIElements;

public class SettingsMenuUI : MonoBehaviour
{
    [SerializeField] Slider _soundSlider;
    [SerializeField] Slider _musicSlider;

    public float soundvalue;
    public float musicvalue;

    public void SoundVolumeChange(float volumeValue)
    {
        soundvalue = volumeValue;
    }

    public void MusicVolumeChanged(float musicValue)
    {
        musicvalue = musicValue;
    }

    public void HideSettings()
    {
        gameObject.SetActive(false);
        // show PauseMenu
    }
}
