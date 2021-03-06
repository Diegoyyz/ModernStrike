﻿using Assets.Scripts.FSM.EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : Entity
{
    public GameObject deathDrop;
    public EnemyIDEnum iD;
    [SerializeField]
    private float maxDistToTarget;
    [SerializeField]
    protected EnemyState currentState;
    [SerializeField]
    protected int maxAmmo;
    [SerializeField]
    [Range(1f, 5)]
    public float fireRate;
    protected int currentAmmo;
    [SerializeField]
    protected Transform projectileSpawnpoint;
    [SerializeField]
    protected GameObject deathEffect;
    private new void Awake()
    {
        base.Awake();
        currentAmmo = maxAmmo;
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }
    public void Update()
    {
        if (currentHp <= 0)
        {
            Die();
        }
    }
    public void Shot()
    {
        var bullet = PoolManager.Instance.INfos[2].GetProjectile();
        bullet.transform.position = projectileSpawnpoint.transform.position;
        currentAmmo--;
        if (_lineOfSight.target == null)
        {
            bullet.transform.rotation = transform.rotation;
        }
        else
        {
            bullet.transform.LookAt(_lineOfSight.target.transform);
        }
    }
    public bool TargetOnShotDistanse()
    {
        if (_lineOfSight.distToTarget() <= _lineOfSight.shootingDistance)
            return true;
        else return false;
    }
    protected override void Die()
    {
        if (deathDrop != null)
        {
            var toSpawn = Instantiate(deathDrop);
            var toSpawn2 = Instantiate(deathEffect);
            toSpawn2.transform.position = transform.position;
            toSpawn2.transform.rotation = Quaternion.identity;
            toSpawn.transform.position = transform.position;
            toSpawn.transform.rotation = Quaternion.identity;
        }
        EventManager.EnemyDied(iD);

        Destroy(this.gameObject);
    }
    public void SetState(EnemyState state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        gameObject.name = "enemy fsm" + state.GetType().Name;
        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }
}
