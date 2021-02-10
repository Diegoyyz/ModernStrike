using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MachineGun : Weapon
{
    [SerializeField]
    private VisualEffect muzzleflash;   

    private void Update()
    {
        if (Input.GetKey(FireKey) && currentAmmo>0)
        {
            StartCoroutine("DelayedShot", fireRate);
        }
    }
   
    public override void Shot()
    {
        var bullet = PoolManager.Instance.INfos[0].GetProjectile();
        muzzleflash.Play();
        currentAmmo--;
        bullet.transform.position = transform.position;
        if (targeter.target == null||!targeter.EnemyInFow(targeter.target))
        {
            bullet.transform.rotation =transform.rotation;
        }
        else
        {
            muzzleflash.transform.LookAt(targeter.target.transform);
            bullet.transform.LookAt(targeter.target.transform);
        }
    }
}
