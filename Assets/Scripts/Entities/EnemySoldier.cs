using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier : Enemy
{   
    private void Start()
    {
        homePos = transform.position;
        SetState(new PatrolState(this));
    }
    public void Update()
    {
        currentState.Tick();
        targetInSight = _lineOfSight.isTargetInSight();
        if (currentHp<=0)
        {
            Die();
        }
    }
    public void SetState(EnemyState state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        gameObject.name = "Enemy Eoldier- " + state.GetType().Name;
        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }
    public bool TargetOnShotDistanse()
    {
        if (_lineOfSight.distToTarget() <= shootingDistance)
            return true;
        else return false;
    }
    private new void Awake()
    {
        base.Awake();
        targetInSight = _lineOfSight.isTargetInSight();
    } 
    public void Shot()
    {
        var bullet = PoolManager.Instance.INfos[2].GetProjectile();
        bullet.transform.position = transform.position;
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
    protected override void Die()
    {
        base.Die();
        EnemiesManager.Instance.enemyList.Remove(this.gameObject);
        EventManager.EnemyDied(iD);
    }
}
