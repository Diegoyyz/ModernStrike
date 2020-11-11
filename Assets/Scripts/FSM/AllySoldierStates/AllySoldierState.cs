using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllySoldierState
{
    protected allySoldier actor;
    
    [SerializeField]
    private float pickUpDistance;
    public abstract void Tick();
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public AllySoldierState(allySoldier character)
    {
        this.actor = character;
    }
   
}
