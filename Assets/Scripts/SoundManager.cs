using UnityEngine;
using UnityEngine.Audio; // Обязательно!

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioMixer mainMixer; // Перетащите ваш микшер сюда в инспекторе

    public float musicVal = 0.5f;
    public float sfxVal = 0.5f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SetMusicVolume(musicVal);
        SetSFXVolume(sfxVal);
    }

    public void SetMusicVolume(float value)
    {
        musicVal = value; // Сохраняем "число" для слайдера
        float db = Mathf.Log10(Mathf.Max(0.0001f, value)) * 20;
        mainMixer.SetFloat("MusicVolume", db);
    }

    public void SetSFXVolume(float value)
    {
        sfxVal = value; // Сохраняем "число" для слайдера
        float db = Mathf.Log10(Mathf.Max(0.0001f, value)) * 20;
        mainMixer.SetFloat("SFXVolume", db);
    }
}
