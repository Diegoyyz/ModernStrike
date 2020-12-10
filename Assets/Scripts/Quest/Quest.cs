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
    public int countCurrent;
    public virtual void complete()
    {
        grantReward();
        progressionText.color = Color.red;
        descriptionText.color = Color.red;
    }
    protected virtual void Awake()
    {
        EventManager.OnquestProgrestChanged += QuestUpdate;
    }  
    void QuestUpdate(Quest quest)
    {
        progressionText.text = countCurrent + "/" + goal.countNeeded;
    }
    protected void incrementCount(int amount)
    {
        countCurrent = Mathf.Min(countCurrent + 1, goal.countNeeded);
        if (countCurrent >= goal.countNeeded && !completed)
        {
            completed = true;
            Debug.Log("Goal Completed!");
            complete();
        }
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

