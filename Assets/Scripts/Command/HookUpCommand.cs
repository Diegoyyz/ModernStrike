﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookUpCommand : Command
{
    public override void Execute(PlayerController actor)
    {
        actor.hookUp();
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
