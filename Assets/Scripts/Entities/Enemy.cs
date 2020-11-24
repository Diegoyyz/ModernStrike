using Assets.Scripts.FSM.EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

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
}
