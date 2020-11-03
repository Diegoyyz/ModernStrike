using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState  
{   
        protected Enemy actor;
        public abstract void Tick();
        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }

        public EnemyState(Enemy character)
        {
            this.actor = character;
        }
   
}
