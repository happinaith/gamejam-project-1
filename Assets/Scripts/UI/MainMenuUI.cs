using UnityEngine;
using UnityEngine.Audio;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] private GameObject settings;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void StartMainGame()
    {
        audioSource.Play();
        Loader.Load(Loader.Scene.GameIntro);
    }

    public void OpenSettings()
    {
        audioSource.Play();
        settings.SetActive(true);
    }

    public void CloseGame()
    {
        audioSource.Play();
        Application.Quit();
    }
}
