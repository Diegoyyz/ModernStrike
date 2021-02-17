﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBoat : Enemy
{
    [SerializeField]
    private Transform[] Waypoints;
    public Transform nexWaypoint;
    [SerializeField]
    private float WaypointGapdistance;
    [SerializeField]
    private Transform turrette;
    Transform returnRandomPoint()
    {
        int D = Random.Range(0, Waypoints.Length);
        nexWaypoint = Waypoints[D];
        return Waypoints[D];
    }
    private void Start()
    {
        SetState(new EBPatrolState(this));
        agent.SetDestination(returnRandomPoint().position);
    }
    public new void Update()
    {       
        currentState.Tick();
        if (currentHp <= 0)
        {
            Die();
        }
    }
    public void Patrol()
    {
        if (Vector3.Distance(transform.position, nexWaypoint.position)<=WaypointGapdistance)
        {
            agent.SetDestination(returnRandomPoint().position);
        }
       
    }
}
