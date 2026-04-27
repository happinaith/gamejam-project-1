using UnityEngine;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] private GameObject settings;
    

    public void StartMainGame()
    {
        // SceneManager.LoadScene();
    }

    public void OpenSettings()
    {
        // Hide Main menu for now and open settings

        settings.SetActive(true);
    }

    public void CloseGame()
    {
        // Close the game?
    }
}
