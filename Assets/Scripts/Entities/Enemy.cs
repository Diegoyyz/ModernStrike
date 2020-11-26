﻿using Assets.Scripts.FSM.EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public GameObject deathDrop;
    private void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        if (currentHp<=0)
        {
            Die();
        }
    }
    protected override void Die()
    {
        if (deathDrop!=null)
        {
            var toSpawn = Instantiate(deathDrop);
            toSpawn.transform.position = transform.position;
            toSpawn.transform.rotation = Quaternion.identity;
        }
        Destroy(this.gameObject);
    }

}
