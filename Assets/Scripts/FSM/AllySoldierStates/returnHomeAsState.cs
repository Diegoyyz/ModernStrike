using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnHomeAsState : AllySoldierState
{
    public returnHomeAsState(allySoldier character) : base(character)
    {
        actor = character;
    }
    public override void Tick()
    {
        actor.moveTowardHome();
        if (Vector3.Distance(actor.transform.position, actor.homePos) <= 0.5)
        {
            actor.SetState(new IdleAsState(actor));
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
