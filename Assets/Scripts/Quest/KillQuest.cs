using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using questSystem;


public class KillQuest : Quest
{
    [SerializeField]
    private EnemyIDEnum enemytokillID;
    [SerializeField]
    [Range(1,10)]
    public int amountToKill;

    private void Awake()
    {
        goal = new KillGoal(amountToKill, enemytokillID, this);
        EventManager.OnquestProgresChanged += QuestUpdate;
        descriptionText.text = "Kill "+ goal.countNeeded +" " + enemytokillID.ToString();
        progressionText.text = goal.countCurrent + "/" + goal.countNeeded;
    }   
}
