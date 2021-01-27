using Assets.Scripts.FSM.EnemyStates;
using UnityEngine;

public class FollowTargetState : EnemyState
{
    protected EnemySoldier actor;

    public FollowTargetState(EnemySoldier character) 
    {
        actor = character;
    }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }
    public override void Tick()
    {
        actor.moveTowardsTarget();
        actor.aimTarget();
        if (actor.TargetOnShotDistanse())
        {
            actor.SetState(new ShootEnemyState(actor));
        }
        else if (!actor.targetInSight)
            actor.SetState(new ReturnHomeState(actor));
    }
}

