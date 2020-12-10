using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace questSystem
{
    [CreateAssetMenu(fileName = "CollectGoal", menuName = "ScriptableObjects/CollectGoal", order = 1)]
    public class CollectGoal : Goal
{
        public int enemyID;
        public CollectGoal(int amountNeeded, int itemID, Quest quest)
        {
            countNeeded = amountNeeded;
            completed = false;
            this.enemyID = itemID;
            this.quest = quest;
        }       
    }
}
