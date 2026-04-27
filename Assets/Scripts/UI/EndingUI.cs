using TMPro;
using UnityEngine;

public class EndingUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textEnd;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (GameManager.instance.isDead)
        {
            textEnd.text = "ВЫ ПРОИГРАЛИ!";
            textEnd.color = Color.red;
        }
        else
        {
            textEnd.text = "ВЫ ВЫИГРАЛИ!";
            textEnd.color = Color.green;
        }
    }

    private void OnDestroy()
    {

    }

    public void LoadMenu()
    {
        if (audioSource != null) audioSource.Play();
        Time.timeScale = 1.0f;
        Loader.Load(Loader.Scene.MainMenu);
    }

    public void LoadAgain()
    {
        if (audioSource != null) audioSource.Play();
        Time.timeScale = 1.0f;
        Loader.Load(Loader.Scene.GameScene);
    }
}
