using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using questSystem;


public class Quest : MonoBehaviour
{
    public string description;
    public string progression;
    public Text descriptionText;
    public Text progressionText;
    public Goal goal;
    public bool completed;
    public List<string> rewards;
    public virtual void complete()
    {
        grantReward();
        progressionText.color = Color.red;
        descriptionText.color = Color.red;
    }
    private void Awake()
    {
        goal = new KillGoal(1, 1, this);
        EventManager.OnquestProgrestChanged += QuestUpdate;
    }
    private void Start()
    {
        descriptionText.text = description;
        progressionText.text = goal.countCurrent+"/"+goal.countNeeded;
    }
    void QuestUpdate(Quest quest)
    {
        progressionText.text = goal.countCurrent + "/" + goal.countNeeded;
    }
    public void grantReward()
    {
        Debug.Log("rewarded");
        foreach (var item in rewards)
        {
            Debug.Log(item);
        }
        Destroy(this);
    }
}

