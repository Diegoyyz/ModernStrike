using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ReverseCommand : Command
{ 
    public override void Execute(PlayerController actor)
    {
        actor.Reverse();        
    }
    public override void Execute(PlayerController actor, float direction)
    {
        throw new System.NotImplementedException();
    }
    public override void Trigger(PlayerController actor, float direction)
    {
        actor.OnMove(direction);
    }
    public override void Trigger(PlayerController actor)
    {
        actor.OnStopMovingBW();
    }
}
