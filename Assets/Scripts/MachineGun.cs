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
        FindClosestEnemy();
        if (Input.GetKey(FireKey))
        {
            StartCoroutine("DelayedShot", fireRate);
        }
    }
    public override void Shot()
    {
        var bullet = PoolManager.Instance.INfos[0].GetProjectile();
        muzzleflash.Play();
        bullet.transform.position = transform.position;
        if (target == null||!EnemyInFow(target))
        {
            bullet.transform.rotation =transform.rotation;
        }
        else
        {
            muzzleflash.transform.LookAt(target.transform);
            bullet.transform.LookAt(target.transform);
        }
    }
}
