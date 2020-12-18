using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Enemy
{

    private new void Awake()
    {
        base.Awake();
        SetState(new IdleTurretState(this));
    }   
    private new void Update()
    {
        base.Update();
        currentState.Tick();
        targetInSight = _lineOfSight.isTargetInSight();
    }
    public void aimToTarget()
    {
        transform.LookAt(_lineOfSight.target);
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

}
