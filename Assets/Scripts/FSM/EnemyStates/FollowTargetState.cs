using UnityEngine;



    public class FollowTargetState : EnemyState
{
        public FollowTargetState(Enemy character) : base(character)
        {
        }     
        public override void OnStateEnter()
        {
            base.OnStateEnter();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
        public override void Tick()
        {
        actor.moveTowardTarget();
        }           
    }
