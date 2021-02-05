using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private int counter;
     private void Start()
    {
        counter = 0;
    }
    private void Update()
    {
        if (Input.GetKeyUp(FireKey))
        {
            StartCoroutine("DelayedShot", fireRate);
        }
        if (counter >= spawnPoints.Length)
        {
            counter = 0;
        }

    }    
    public override void Shot()
    {        
        var bullet = PoolManager.Instance.INfos[1].GetProjectile();
        bullet.transform.position = spawnPoints[counter].position;
        counter++;
        currentAmmo--;
        if (targeter.target == null || !targeter.EnemyInFow())
        {
            bullet.transform.rotation = transform.rotation;
        }
        else
        {
            bullet.transform.LookAt(targeter.target.transform);
        }
    }
}
