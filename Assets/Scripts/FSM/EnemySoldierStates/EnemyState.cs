using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState  
{   
        protected EnemySoldier actor;
        public abstract void Tick();
        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }

        public EnemyState(EnemySoldier character)
        {
            this.actor = character;
        }
   
}
