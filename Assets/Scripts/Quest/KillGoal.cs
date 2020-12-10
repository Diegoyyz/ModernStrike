using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace questSystem
{
    [CreateAssetMenu(fileName = "KillGoal", menuName = "ScriptableObjects/KillGoal", order = 1)]

    public class KillGoal : Goal
    {
        public int enemyID;
        public KillGoal(int amountNeeded, int enemyID, Quest quest)
        {
            countNeeded = amountNeeded;
            completed = false;
            this.enemyID = enemyID;
            this.quest = quest;
        }
        
    }

}
