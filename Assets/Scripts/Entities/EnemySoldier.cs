using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier : Enemy
{
 
    [SerializeField]
    private Transform turret;

    private void Start()
    {
        homePos = transform.position;
        SetState(new PatrolState(this));
    }
    public new void Update()
    {    
        currentState.Tick();
        targetInSight = _lineOfSight.isTargetInSight();
        if (currentHp<=0)
        {
            Die();
        }
    }
    public void aimTarget()
    {
        turret.LookAt(_lineOfSight.target);
    }
   
    private new void Awake()
    {
        base.Awake();
        targetInSight = _lineOfSight.isTargetInSight();
    }    
    protected override void Die()
    {
        base.Die();
        EnemiesManager.Instance.enemyList.Remove(this.gameObject);
    }
}
