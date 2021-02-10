using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : Enemy
{
    [SerializeField]
    private Transform[] Waypoints;
    public Transform nextarget;
    [SerializeField]
    private Transform turrette;
    Vector3 returnRandomPoint()
    {
        int D = Random.Range(0, Waypoints.Length);
        nextarget = Waypoints[D];
        return Waypoints[D].position;
    }
    private void Start()
    {
        agent.SetDestination(returnRandomPoint());
        turrette = transform.Find("Enemy Turret");
    }
    public new void Update()
    {
        if (turrette!=null)
        {       
        if (agent.remainingDistance < 30f )
        {
            agent.SetDestination(returnRandomPoint());
        }
        }

    }
}
