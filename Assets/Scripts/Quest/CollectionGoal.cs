using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace questSystem

{
    public class CollectionGoal : Goal
    {
        public int itemID;
        public CollectionGoal(int amountNeeded, int itemID,Quest quest)
        {
            countCurrent = 0;
            countNeeded = amountNeeded;
            completed = false;
            this.quest = quest;
            this.itemID = itemID;
           
        }
        void itemFound(int itemID)
        {
            if (this.itemID==itemID)
            {
                incrementCount(1);
                if (this.completed)
                {
                    //suscribir a evento de item found en event controller
                }
            }
        }

    }
}

