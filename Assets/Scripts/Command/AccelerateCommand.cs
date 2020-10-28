using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateCommand : Command
{
    public override void Execute(PlayerController player)
    {
        player.Accelerate();
    }

    public override void Execute(PlayerController actor, float direction)
    {
        throw new System.NotImplementedException();
    }
    public override void Trigger(PlayerController actor, float direction)
    {
        actor.OnMove(new Vector3(0, direction, 0));
    }
    public override void Trigger(PlayerController actor)
    {
        actor.OnStopMovingFW();
     }
}
