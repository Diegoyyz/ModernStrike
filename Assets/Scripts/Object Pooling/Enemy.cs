using Assets.Scripts.FSM.EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{  

    [SerializeField]
    public bool targetInSight;
    [SerializeField]
    private float shootingDistance;   
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
    [SerializeField]
    private EnemyState currentState;
    private LineOfSight _lineOfSight;
    public Vector3 homePos;
    bool _targetInSight;

    private void Start()
    {
        currentAmmo = maxAmmo;
        homePos = transform.position;
        SetState(new PatrolState(this));
    }
    private void Awake()
    {
        _lineOfSight = GetComponent<LineOfSight>();
        _lineOfSight.shootingDistance = shootingDistance;
        targetInSight = _lineOfSight.isTargetInSight();
    }

    public void Update()
    {
        currentState.Tick();
        targetInSight = _lineOfSight.isTargetInSight();
    }
    public void SetState(EnemyState state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        gameObject.name = "Enemy- " + state.GetType().Name;
        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    } 
    public bool  targetOnShotDistanse()
    {
        if (_lineOfSight.distToTarget() <= shootingDistance)
        return true;
        else return false;
    }
    public void moveTowardTarget()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.LookAt(new Vector3(0, 0, _lineOfSight.target.position.z), transform.up); 
              
    }
    public void moveTowardHome()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.LookAt(homePos, transform.up);
    }
    private IEnumerator DelayedShot(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentAmmo--;
        Debug.Log("EnemyShot");
        StopCoroutine("DelayedShot");
    }
    public void Shot()
    {
        StartCoroutine("DelayedShot", fireRate);
    }
   
    protected override void Die()
    {
        EnemiesManager.Instance.enemyList.Remove(this.gameObject);
        base.Die();
    }
    
}
