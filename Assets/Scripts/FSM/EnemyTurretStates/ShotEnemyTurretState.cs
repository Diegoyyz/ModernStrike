using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyTurretState : EnemyState
{
    private float nextFire;
    protected EnemyTurret actor;
    public ShotEnemyTurretState(EnemyTurret character)
    {
        actor = character;
    }
    public override void Tick()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + actor.fireRate;
            actor.Shot();
        }
        actor.aimToTarget();
        if (actor.TargetOnShotDistanse() == false)
        {
            actor.SetState(new IdleTurretState(actor));
        }
    }   
    public override void OnStateEnter()
    {
        nextFire = actor.fireRate;
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }

}
