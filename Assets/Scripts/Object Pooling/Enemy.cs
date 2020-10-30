using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{  

    [SerializeField]
    public bool _targetInSight;
    [SerializeField]
    private float shootingDistance;
    [SerializeField]
    private float viewDistance;
    private float distancetoTarget;
    [SerializeField]
    private float maxDistToTarget;
    [SerializeField]
    private int maxAmmo;
    [SerializeField]
    [Range(.1f,3)]
    private float fireRate;
    [SerializeField]
    [Range(0, 20)]
    private float speed;
    private int currentAmmo;
    private EnemyState currentState;
    private void Start()
    {
        currentAmmo = maxAmmo;
    }
    public void Update()
    {
        currentState.Tick();
    }
    public void SetState(EnemyState state)
    {
        if (currentState != null)
            currentState.OnStateExit();
        currentState = state;
        gameObject.name = "Enemy- " + state.GetType().Name;
        if (currentState != null)
            currentState.OnStateEnter();
    }
    public bool isTargetInSight()
    {      
        if (Target == null)
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
        return Vector3.Distance(Target.transform.position, transform.position);
    }


    public void moveTowardTarget()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.LookAt(new Vector3(0, 0, Target.transform.position.z), transform.up);
       
            if (distToTarget() >= shootingDistance)
            {
                moveTowardTarget();
            }
            else if (distancetoTarget <= shootingDistance)
            {
                StartCoroutine("DelayedShot", fireRate);
            }
        
    }
    private IEnumerator DelayedShot(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentAmmo--;
        Shot();
        StopCoroutine("DelayedShot");
    }
    private void Shot()
    {
        Debug.Log("EnemyShot");
    }
    protected bool TargetInSight()
    {
        if (Target != null)
        {
            var distance = Vector3.Distance(Target.transform.position, transform.position);
            if (distance <= viewDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    protected override void Die()
    {
        EnemiesManager.Instance.enemyList.Remove(this.gameObject);
        base.Die();
    }
    private void OnDrawGizmosSelected()
    {
        if (Target != null && _targetInSight)
        {
            Gizmos.color = _targetInSight ? Color.green : Color.red;
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, Target.transform.position);
        }
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingDistance);
        Gizmos.color = TargetInSight() ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, Target.transform.position);
    }
}
