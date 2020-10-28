using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command  
{
    public abstract void Execute(PlayerController actor);
    public abstract void Execute(PlayerController actor,float direction);
    public abstract void Trigger(PlayerController actor, float direction);
    public abstract void Trigger(PlayerController actor);


}
