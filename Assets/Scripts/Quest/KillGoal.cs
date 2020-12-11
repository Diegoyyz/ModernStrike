using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace questSystem
{
    public class KillGoal : Goal
    {
        public int enemyID;
        public KillGoal(int amountNeeded, int enemyID, Quest quest)
        {
            countCurrent = 0;
            countNeeded = amountNeeded;
            completed = false;
            EventManager.OnEnemyDied +=enemyKill;
            this.enemyID = enemyID;
            this.quest = quest;
        }
        void enemyKill(int enemyID)
        {
            if (this.enemyID == enemyID)
            {
                incrementCount(1);
                EventManager.QuestProgressChanged(this.quest);
            }
        }
    }

}
