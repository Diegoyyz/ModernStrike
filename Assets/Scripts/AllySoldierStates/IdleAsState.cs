using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAsState : AllySoldierState
{
    public IdleAsState(allySoldier character) : base(character)
    {
        actor = character;
    }
    public override void Tick()
    {
       
        if (actor.targetInSight)
        {
            if (!actor.targetOnPickupDistanse())
            {
              actor.SetState(new FollowHeroState(actor));
            }
        }
        
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
