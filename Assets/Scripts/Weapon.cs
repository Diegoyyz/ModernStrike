using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    protected float fireRate;
    [SerializeField]
    protected int maxAmmo;
    public int currentAmmo;
    [SerializeField]
    protected KeyCode FireKey;

    public TargetManager targeter;

    public virtual void Shot()
    {
    }
    private void Awake()
    {
        currentAmmo = maxAmmo;
    }
    public void rechargeAmmo(int amount)
    {
        currentAmmo += amount;
    }
    private IEnumerator DelayedShot(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentAmmo--;
        Shot();
        StopCoroutine("DelayedShot");
    }
}
