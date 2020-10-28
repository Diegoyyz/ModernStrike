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
        FindClosestEnemy();
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
        if (target == null || !EnemyInFow(target))
        {
            bullet.transform.rotation = transform.rotation;
        }
        else
        {
            bullet.transform.LookAt(target.transform);
        }
    }
}
