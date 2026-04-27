using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public GameObject ui;
    public bool isDead = false;

    void Awake()
    {
        instance = this;
        EventBus.OnPlayerDead += EventBus_OnPlayerDead;
        EventBus.OnPlayerWin += EventBus_OnPlayerWin; 
    }

    private void EventBus_OnPlayerWin()
    {
        Time.timeScale = 0;
        ui.SetActive(true);
    }

    private void EventBus_OnPlayerDead()
    {
        Time.timeScale = 0;
        isDead = true;
        ui.SetActive(true);
    }

    private void OnDestroy()
    {
        EventBus.OnPlayerDead -= EventBus_OnPlayerDead;
        EventBus.OnPlayerWin -= EventBus_OnPlayerWin;
    }
}
