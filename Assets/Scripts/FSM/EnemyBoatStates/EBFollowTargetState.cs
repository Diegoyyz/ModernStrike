using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EBFollowTargetState : EnemyState
{
    protected EnemyBoat actor;
    public EBFollowTargetState(EnemyBoat character)
    {
        actor = character;
    }
    public override void Tick()
    {
        actor.moveTowardsTarget();      
        if (!actor.targetInSight)
            actor.SetState(new EBPatrolState(actor));
    }
}
