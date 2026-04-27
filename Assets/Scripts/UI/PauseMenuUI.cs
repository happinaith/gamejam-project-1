using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    public GameObject pauseUI;
    public static bool isPaused = false;

    private AudioSource pauseAudioSource;

    private void Awake()
    {
        pauseAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        if (pauseAudioSource != null && pauseUI.activeSelf) pauseAudioSource.Play();
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart()
    {
        pauseAudioSource.Play();
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.GameScene);
    }

    public void LoadMenu()
    {
        pauseAudioSource.Play();
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.MainMenu);
    }
}
