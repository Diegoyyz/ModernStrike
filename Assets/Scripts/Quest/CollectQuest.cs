using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using questSystem;

public class CollectQuest : Quest
{
    private void Awake()
    {
        goal = new CollectGoal(5, 1, this);
        EventManager.OnquestProgresChanged += QuestUpdate;
        descriptionText.text = "Rescue " + goal.countNeeded + " Ally Soldiers";
        progressionText.text = goal.countCurrent + "/" + goal.countNeeded;
    }

}
