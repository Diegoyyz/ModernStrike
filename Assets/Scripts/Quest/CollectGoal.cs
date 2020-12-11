using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace questSystem
{
    public class CollectGoal : Goal
    {
        public int itemID;
        public CollectGoal(int amountNeeded, int enemyID, Quest quest)
        {
            countCurrent = 0;
            countNeeded = amountNeeded;
            completed = false;
            EventManager.OnItemGrabbed += itemCollect;
            this.itemID = enemyID;
            this.quest = quest;
        }
        void itemCollect(int itemID)
        {
            if (this.itemID == itemID)
            {
                incrementCount(1);
                Debug.Log("incremento item" + itemID);
                EventManager.QuestProgressChanged(this.quest);
            }
        }
    }
}
