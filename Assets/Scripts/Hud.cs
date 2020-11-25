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
    private void Start()
    {
        actor = GameManager.Instance.player;
    }
    void Update()
    {
        HealtBar.fillAmount = actor.CurrentHealt / actor.maxHp;
        FuelBar.fillAmount = actor.CurrentFuel / actor.maxFuel;
    }
}
