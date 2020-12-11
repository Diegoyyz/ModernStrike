using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace questSystem
{
    public class Goal
    {
        public int countNeeded;
        public int countCurrent;
        public bool completed;
        public Quest quest;
        protected void incrementCount(int amount)
        {
            countCurrent = Mathf.Min(countCurrent + 1, countNeeded);
            if (countCurrent >= countNeeded && !completed)
            {
                completed = true;
                Debug.Log("Goal Completed!");
                quest.complete();
            }
        }
    }
}
