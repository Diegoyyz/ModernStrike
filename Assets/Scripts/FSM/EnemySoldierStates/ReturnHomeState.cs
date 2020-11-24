using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.FSM.EnemyStates
{
    public class ReturnHomeState : EnemyState
    {
        public ReturnHomeState(EnemySoldier character) : base(character)
        {
            actor = character;
        }
        public override void Tick()
        {
            actor.moveTowardHome();
            if (Vector3.Distance(actor.transform.position, actor.homePos) <= 0.5)
            {
                actor.SetState(new PatrolState(actor));
            }
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
        }
        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }
}