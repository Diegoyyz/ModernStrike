using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    bool _targetInSight;
    public Transform target;
    public float viewDistance;
    public float shootingDistance;   

    private void Start()
    {
        target = GameManager.Instance.player.transform;
    }
    public bool isTargetInSight()
    {
        if (target == null|| distToTarget()==0)
        {
            _targetInSight = false;
        }
        if (distToTarget() <= viewDistance)
        {
            _targetInSight = true;
        }
        else
        {
            _targetInSight = false;
        }
        return _targetInSight;
    }
    public float distToTarget()
    {
        if (target != null)
        {
            return Vector3.Distance(target.transform.position, transform.position);
        }
        else
            return 0;        
    }
    private void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            Gizmos.color = _targetInSight ? Color.green : Color.red;
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, target.transform.position);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingDistance);
        Gizmos.color = isTargetInSight() ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, target.transform.position);
        }
    }
}
