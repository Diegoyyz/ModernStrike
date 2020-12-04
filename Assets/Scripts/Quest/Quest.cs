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
        Debug.Log("quest completed");
        grantReward();
    }
    private void Start()
    {
        descriptionText.text = description;
        progressionText.text = goal.countNeeded+"/"+goal.countCurrent;
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

