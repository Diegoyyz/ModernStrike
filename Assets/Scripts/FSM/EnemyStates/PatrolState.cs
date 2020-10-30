using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.FSM.EnemyStates
{
    public class PatrolState : EnemyState
    {
        public PatrolState(Enemy character) : base(character)
        {
            actor = character;
        }
        public override void OnStateEnter()
        {
            //hacer cosas anteriores a la patrulla
        }

        public override void OnStateExit()
        {
            //prepararse para dejar la patrulla
        }

        public override void Tick()
        {

            if (actor.isTargetInSight())
            {
                actor.SetState(new FollowTargetState(actor));
            }
        }

    }
}