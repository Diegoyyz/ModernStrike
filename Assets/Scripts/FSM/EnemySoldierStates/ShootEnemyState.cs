using Assets.Scripts.FSM.EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyState : EnemyState
{
    private float nextFire;
    public ShootEnemyState(EnemySoldier character) : base(character)
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

        if (actor.TargetOnShotDistanse()==false)
        {
          actor.SetState(new PatrolState(actor));
        }
    }
    public override void OnStateEnter()
    {
        nextFire =actor.fireRate;
    }
   
    public override void OnStateExit()
    {
        base.OnStateExit();
    }

}
