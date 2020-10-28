using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLCommand : Command
{
    public override void Execute(PlayerController actor)
    {
        actor.Turn(-1);
    }
    public override void Execute(PlayerController actor, float direction)
    {
        throw new System.NotImplementedException();
    }
    public override void Trigger(PlayerController actor, float direction)
    {
        actor.OnTurn(new Vector3(0, direction, 0));
    }
    public override void Trigger(PlayerController actor)
    {
        actor.onStopTurning(new Vector3(0, -1, 0));
    }
}
