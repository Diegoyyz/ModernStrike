using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace questSystem
{
    public class KillEnemieQuest : Quest
    {
        public int enemyID;
         protected new void Awake()
        {
            base.Awake();
            goal = new KillGoal(1, 1, this);
            descriptionText.text = "Kill "+goal.countNeeded+ " soldiers";
            progressionText.text = countCurrent + "/" + goal.countNeeded;
            rewards = new List<string>() { "combustible", "tiempo", "cositas ricas" };
            EventManager.OnEnemyDied += enemyKill;
        }
        void enemyKill(int enemyID)
        {
            if (this.enemyID == enemyID)
            {
                incrementCount(1);
                EventManager.QuestProgressChanged(this);
            }
        }

    }
}
