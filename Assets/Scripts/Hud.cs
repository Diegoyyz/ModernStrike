using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField]
    private Image FuelBar;
    [SerializeField]
    private Image HealtBar;
    private PlayerController actor;
    [SerializeField]
    private int maxCargo;
    [SerializeField]
    private Image[] cargos;
    private int cargoCount;
    private void Start()
    {
        actor = GameManager.Instance.player;
        foreach (var item in cargos)
        {
            item.gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        PlayerController.OnGetCargo += addCargo;
        PlayerController.OnDisharge += dischargeCargo;
    }
    private void OnDisable()
    {
        PlayerController.OnGetCargo -= addCargo;
    }
    void Update()
    {
        HealtBar.fillAmount = actor.CurrentHealt / actor.maxHp;
        FuelBar.fillAmount = actor.CurrentFuel / actor.maxFuel;
    }
    public void addCargo()
    {
        cargos[cargoCount].gameObject.SetActive(true);
        cargoCount+=1;
    }
    public void dischargeCargo()
    {
        foreach (var item in cargos)
        {
            item.gameObject.SetActive(false);
        }
        cargoCount = 0;
    }

public void removeCargo()
    {
        cargos[cargoCount].gameObject.SetActive(false);
        cargoCount-=1;
    }
}
