using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using questSystem;


public class KillQuest : Quest
{
    private void Awake()
    {
        goal = new KillGoal(1, 1, this);
        EventManager.OnquestProgresChanged += QuestUpdate;
        descriptionText.text = "Kill "+ goal.countNeeded +" enemies";
        progressionText.text = goal.countCurrent + "/" + goal.countNeeded;
    }   
}
