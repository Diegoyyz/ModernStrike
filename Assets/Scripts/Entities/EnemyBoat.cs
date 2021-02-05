using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : Enemy
{
    [SerializeField]
    private Transform[] Waypoints;
    public Transform nextarget;
    Vector3 returnRandomPoint()
    {
        int D = Random.Range(0, Waypoints.Length);
        nextarget = Waypoints[D];
        return Waypoints[D].position;
    }
    private void Start()
    {
        agent.SetDestination(returnRandomPoint());
    }
    public new void Update()
    {
        if (agent.remainingDistance < 30f )
        {
            agent.SetDestination(returnRandomPoint());
        }

    }
}
