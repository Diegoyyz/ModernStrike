using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace questSystem
{
    public class KillEnemieQuest : Quest
    {      
        private void Awake()
        {
            description = "Kill Enemy soldiers ";
            rewards = new List<string>() { "combustible", "tiempo", "cositas ricas" };
            goal = new KillGoal(5, 0, this);
        }
        void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
