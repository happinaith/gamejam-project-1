using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject settings;

    public void ContinueGame()
    {
        // SceneManager.Time bla bla
        gameObject.SetActive(false);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
    }

    public void BackToMenu()
    {
        // SceneManager.LoadScene ??
    }
}
