using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTurretState : EnemyState
{
    protected EnemyTurret actor;
    public IdleTurretState(EnemyTurret character)
    {
        actor = character;
    }

    public override void Tick()
    {
        if (actor.TargetOnShotDistanse())
        {
            actor.SetState(new ShotEnemyTurretState(actor));
        }
    }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}
