using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using questSystem;

public class CollectQuest : Quest
{
    [SerializeField]
    [Range(1, 10)]
    public int amountToCollect;
    private void Awake()
    {
        goal = new CollectGoal(amountToCollect, 1, this);
        EventManager.OnquestProgresChanged += QuestUpdate;
        descriptionText.text = "Rescue " + goal.countNeeded + " Ally Soldiers";
        progressionText.text = goal.countCurrent + "/" + goal.countNeeded;
    }

}
