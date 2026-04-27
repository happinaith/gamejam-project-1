using System;
using System.Collections.Generic;
using UnityEngine;

public class EnergyUI : MonoBehaviour
{
    [SerializeField] GameObject energyPrefab;

    List<EnergyImageUI> energies = new List<EnergyImageUI>();

    private void Awake()
    {
        EventBus.OnEnergyPickUp += DrawEnergy;
    }

    private void Start()
    {
        DrawEnergy();
    }

    public void DrawEnergy()
    {
        ClearEnergy();

        for (int i = 0; i < PlayerController.instance.energyPointsMax; i++)
        {
            CreateEmptyEnergy();
        }

        for (int i = 0; i < energies.Count; i++)
        {
            int energyStatusRemainder = (int)Mathf.Clamp(PlayerController.instance.energyPoints - i, 0, 1);
            energies[i].SetEnergyImage((EnergyImageUI.EnergyStatus)energyStatusRemainder);
        }
    }

    public void CreateEmptyEnergy()
    {
        GameObject newEnergy = Instantiate(energyPrefab);
        newEnergy.transform.SetParent(transform);
        newEnergy.transform.localScale = Vector3.one;

        EnergyImageUI energyUI = newEnergy.GetComponent<EnergyImageUI>();
        energies.Add(energyUI);
    }

    public void ClearEnergy()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        energies = new List<EnergyImageUI>();
    }
}
