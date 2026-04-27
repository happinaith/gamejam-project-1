using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] GameObject healthPrefab;

    List<HealthImageUI> healths = new List<HealthImageUI>();

    private void Awake()
    {
        EventBus.OnPlayerDamage += DrawHealth;
        EventBus.OnHealthPickUp += DrawHealth;
    }

    private void Start()
    {
        DrawHealth();
    }

    public void DrawHealth()
    {
        ClearHealth();

        for (int i = 0; i < PlayerController.instance.energyPointsMax; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i < healths.Count; i++)
        {
            int healthStatusRemainder = (int)Mathf.Clamp(PlayerController.instance.healthPoints - i, 0, 1);
            healths[i].SetHealthImage((HealthImageUI.HealthStatus)healthStatusRemainder);
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject newHealth = Instantiate(healthPrefab);
        newHealth.transform.SetParent(transform);
        newHealth.transform.localScale = Vector3.one;

        HealthImageUI healthUI = newHealth.GetComponent<HealthImageUI>();
        healths.Add(healthUI);
    }
    
    public void ClearHealth()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        healths = new List<HealthImageUI>();
    }
}
