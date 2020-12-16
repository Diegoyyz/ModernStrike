using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrolState : EnemyState
{
    protected EnemySoldier actor;

    public PatrolState(EnemySoldier character)
    {
        actor = character;
    }
    public override void OnStateEnter()
    {
        //hacer cosas anteriores a la patrulla
    }

    public override void OnStateExit()
    {
        //prepararse para dejar la patrulla
    }

    public override void Tick()
    {
        if (actor.targetInSight)
        {
            actor.SetState(new FollowTargetState(actor));
        }
    }

}
