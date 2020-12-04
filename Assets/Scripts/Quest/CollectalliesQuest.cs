using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace questSystem
{
    public class CollectalliesQuest : Quest
{
    private void Awake()
    {
        description = "Collect Allies";
        rewards = new List<string>() {"combustible", "tiempo", "cositas ricas" };
        goal = new KillGoal(5,0,this);
    }
    public override void complete()
    {
        base.complete();
    }
}
}
