using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace questSystem
{
    public class KillGoal : Goal
    {
        public EnemyIDEnum enemyID;
        public KillGoal(int amountNeeded, EnemyIDEnum enemyID, Quest quest)
        {
            countCurrent = 0;
            countNeeded = amountNeeded;
            completed = false;
            EventManager.OnEnemyDied +=enemyKill;
            this.enemyID = enemyID;
            this.quest = quest;
        }
        void enemyKill(EnemyIDEnum enemyID)
        {
            if (this.enemyID == enemyID)
            {
                incrementCount(1);
                EventManager.QuestProgressChanged(this.quest);
            }
        }
    }
}
