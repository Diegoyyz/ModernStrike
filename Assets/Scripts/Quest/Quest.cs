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
 
    protected void QuestUpdate(Quest quest)
    {
        progressionText.text = goal.countCurrent + "/" + goal.countNeeded;
    }
    public void grantReward()
    {
        foreach (var item in rewards)
        {
            Debug.Log(item);
        }
        GameManager.Instance.completed++;
        Destroy(this);
    }
}

