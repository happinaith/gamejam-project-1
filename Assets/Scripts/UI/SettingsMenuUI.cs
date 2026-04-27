using UnityEngine;
using UnityEngine.UIElements;

public class SettingsMenuUI : MonoBehaviour
{
    [SerializeField] Slider _soundSlider;
    [SerializeField] Slider _musicSlider;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void HideSettings()
    {
        if (audioSource != null) audioSource.Play();
        gameObject.SetActive(false);
    }
}
