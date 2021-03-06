﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    protected float LookSpeed;
    [SerializeField]
    protected float maxAngle;
    [SerializeField]
    protected float MaxDist;
    [SerializeField]
    protected float targetIndicator;

    private void Update()
    {
        FindClosestEnemy();
    }
    public bool EnemyInFow(Transform enemy)
    {
        Vector3 targetDirection = enemy.position - transform.parent.position;
        var distance = Vector3.Distance(enemy.position, transform.parent.position);
        float Angle = Vector3.Angle(targetDirection, transform.forward);
        if (Angle < maxAngle && (distance <= MaxDist))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool EnemyInFow()
    {
        Vector3 targetDirection = target.position - transform.parent.position;
        var distance = Vector3.Distance(target.position, transform.parent.position);
        float Angle = Vector3.Angle(targetDirection, transform.forward);
        if (Angle < maxAngle && (distance <= MaxDist))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void FindClosestEnemy()
    {
        float Range = MaxDist;
        foreach (var item in EnemiesManager.Instance.enemyList)
        {
            if (item != null)
            {
                float dist = Vector3.Distance(item.transform.position
                       , transform.parent.position);
                if (dist < Range && EnemyInFow(item.transform))
                {
                    Range = dist;
                    target = item.transform;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (target != null && EnemyInFow(target.transform))
        {
            Gizmos.color = EnemyInFow(target.transform) ? Color.green : Color.red;
            Gizmos.DrawLine(transform.position, target.position);
        }
        var rightLimit = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + (rightLimit * MaxDist));

        var leftLimit = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + (leftLimit * MaxDist));
    }
}
