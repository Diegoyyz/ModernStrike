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
    [SerializeField]
    private Text healtNumber;
    private PlayerController actor;
    [SerializeField]
    private int maxCargo;
    [SerializeField]
    private Image[] cargos;
    private int cargoCount;
    [SerializeField]
    private Text WeaponText;
    [SerializeField]
    private Text machinegunBullets;
    [SerializeField]
    private Text Misille;
    private void Start()
    {
        actor = GameManager.Instance.player;
        foreach (var item in cargos)
        {
            item.gameObject.SetActive(false);
        }
        machinegunBullets.text = actor.Weapn1.currentAmmo.ToString();
        Misille.text = actor.Weapn2.currentAmmo.ToString();
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
        machinegunBullets.text = actor.Weapn1.currentAmmo.ToString();
        Misille.text = actor.Weapn2.currentAmmo.ToString();
        HealtBar.fillAmount = actor.HealtPorcentage();
        healtNumber.text = actor.CurrentHealt.ToString();
        FuelBar.fillAmount = actor.FuelPorcentage();
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
