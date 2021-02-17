using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBPatrolState : EnemyState
{
    protected EnemyBoat actor;
    public EBPatrolState(EnemyBoat character)
    {
        actor = character;
    }
    public override void Tick()
    {
        if (!actor.targetInSight)
        {
            actor.Patrol();
        }
        else
        {
            actor.SetState(new EBFollowTargetState(actor));
        }
    }  
}
