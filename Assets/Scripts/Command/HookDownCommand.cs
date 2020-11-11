using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDownCommand : Command
{
    public override void Execute(PlayerController actor)
    {
        if (actor._isHookDown)
        {
            actor.hookUp();
        }
        else
        {
            actor.hookDown();
        }
    }
    public override void Execute(PlayerController actor, float direction)
    {
        throw new System.NotImplementedException();
    }

    public override void Trigger(PlayerController actor, float direction)
    {
        throw new System.NotImplementedException();
    }

    public override void Trigger(PlayerController actor)
    {
        throw new System.NotImplementedException();
    }
}
