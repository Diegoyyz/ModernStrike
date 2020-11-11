using Assets.Scripts.FSM.EnemyStates;
using UnityEngine;

public class FollowTargetState : EnemyState
{
    public FollowTargetState(Enemy character) : base(character)
    {

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
        actor.moveTowardTarget();
        if (actor.targetOnShotDistanse())
        {
            actor.SetState(new ShootEnemyState(actor));
        }
        else if (!actor.targetInSight)
            actor.SetState(new ReturnHomeState(actor));

    }
}

