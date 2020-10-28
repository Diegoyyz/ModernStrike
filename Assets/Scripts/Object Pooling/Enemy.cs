using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

    protected enum EnemyFSM
    {
      Attack,
      Flee,
      Stroll,
      MoveTowardsPlayer
    }

    [SerializeField]
    private bool _targetInSight;
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

    private void Start()
    {
        currentAmmo = maxAmmo;
    }
    public virtual void UpdateEnemy(Transform playerObj)
    {

    }
    private void ViewThings()
    {
        if (currentHp <= 0)
        {
            Die();
        }
        if (Target == null)
        {
            _targetInSight = false;
            return;
        }
        distancetoTarget = Vector3.Distance(Target.transform.position, transform.position);
        if (distancetoTarget <=viewDistance)
        {
            _targetInSight = true;
        }
        else
        {
            _targetInSight = false;

        }
        if (_targetInSight)
        {
            transform.LookAt(new Vector3(0,0,Target.transform.position.z),transform.up);
            if (distancetoTarget >= shootingDistance)
            {
                moveTowardTarget();
            }
            else if (distancetoTarget <= shootingDistance)
            {
                StartCoroutine("DelayedShot", fireRate);
            }
        }
    }

    protected void DoAction(Transform playerObj, EnemyFSM enemyMode)
    {
        float fleeSpeed = 10f;
        float strollSpeed = 1f;
        float attackSpeed = 5f;

        switch (enemyMode)
        {
            case EnemyFSM.Attack:
                //Attack player
                break;
            case EnemyFSM.Flee:
                //Move away from player
                //Look in the opposite direction
                transform.rotation = Quaternion.LookRotation(transform.position - playerObj.position);
                //Move
                transform.Translate(transform.forward * fleeSpeed * Time.deltaTime);
                break;
            case EnemyFSM.Stroll:
                //Look at a random position
                Vector3 randomPos = new Vector3(Random.Range(0f, 100f), 0f, Random.Range(0f, 100f));
                transform.rotation = Quaternion.LookRotation(transform.position - randomPos);
                //Move
                transform.Translate(transform.forward * strollSpeed * Time.deltaTime);
                break;
            case EnemyFSM.MoveTowardsPlayer:
                //Look at the player
                transform.rotation = Quaternion.LookRotation(playerObj.position - transform.position);
                //Move
                transform.Translate(transform.forward * attackSpeed * Time.deltaTime);
                break;
        }
    }



    private void moveTowardTarget()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
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
        //Dibujamos los límites del campo de visión.
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
        // Limite del campo de deteccion automatica
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingDistance);
        Gizmos.color = TargetInSight() ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, Target.transform.position);
    }
}
