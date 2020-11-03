using Assets.Scripts.FSM.EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyState : EnemyState
{
    public ShootEnemyState(Enemy character) : base(character)
    {
        actor = character;
    }
    public override void Tick()
    {
        actor.Shot();
        actor.SetState(new PatrolState(actor));
    }
    public override void OnStateEnter()
    {
        
    }
    public override void OnStateExit()
    {
        base.OnStateExit();

    }

}
