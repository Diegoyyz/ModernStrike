using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
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
        bullet.transform.position = transform.position;
        if (target == null||!EnemyInFow(target))
        {
            bullet.transform.rotation =transform.rotation;
        }
        else
        {
            bullet.transform.LookAt(target.transform);
        }
    }
}
