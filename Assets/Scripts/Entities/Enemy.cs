﻿using Assets.Scripts.FSM.EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{  

   
    [SerializeField]
    private float shootingDistance;   
    [SerializeField]
    private float maxDistToTarget;
    [SerializeField]
    private int maxAmmo;
    [SerializeField]
    [Range(.1f,3)]
    private float fireRate;   
    private int currentAmmo;
    [SerializeField]
    private EnemyState currentState;

    private void Start()
    {
        currentAmmo = maxAmmo;
        homePos = transform.position;
        SetState(new PatrolState(this));
    }
    public override void Awake()
    {
        base.Awake();
        targetInSight = _lineOfSight.isTargetInSight();
    }

    public void Update()
    {
        currentState.Tick();
        targetInSight = _lineOfSight.isTargetInSight();
    }
    public void SetState(EnemyState state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        gameObject.name = "Enemy- " + state.GetType().Name;
        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    } 
    public bool  targetOnShotDistanse()
    {
        if (_lineOfSight.distToTarget() <= shootingDistance)
        return true;
        else return false;
    }
  
    private IEnumerator DelayedShot(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentAmmo--;
        Debug.Log("EnemyShot");
        StopCoroutine("DelayedShot");
    }
    public void Shot()
    {
        StartCoroutine("DelayedShot", fireRate);
    }
   
    protected override void Die()
    {
        EnemiesManager.Instance.enemyList.Remove(this.gameObject);
        base.Die();
    }
    
}