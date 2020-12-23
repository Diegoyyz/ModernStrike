using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHeroState : AllySoldierState
{
    public FollowHeroState(allySoldier character) : base(character)
    {
        actor = character;
    }
    public override void Tick()
    {
        actor.moveTowardTarget();
        if (actor.targetOnPickupDistanse())
        {
            actor.SetState(new IdleAsState(actor));
        }
        else if (!actor.targetInSight)
            actor.SetState(new returnHomeAsState(actor));
    }                      
    public override void OnStateEnter()
    {
        //hacer cosas anteriores a la patrulla
    }

    public override void OnStateExit()
    {
        //prepararse para dejar la patrulla
    }
}
