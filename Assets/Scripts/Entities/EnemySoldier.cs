using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier : Enemy
{
    [SerializeField]
    private float shootingDistance;
    [SerializeField]
    private float maxDistToTarget;
    [SerializeField]
    private int maxAmmo;
    [SerializeField]
    [Range(.1f, 3)]
    private float fireRate;
    private int currentAmmo;
    [SerializeField]
    private EnemyState currentState;
    private void Start()
    {
        currentAmmo = maxAmmo;
        homePos = transform.position;
        SetState(new PatrolState(this));
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
    public bool targetOnShotDistanse()
    {
        if (_lineOfSight.distToTarget() <= shootingDistance)
            return true;
        else return false;
    }
    public override void Awake()
    {
        base.Awake();
        targetInSight = _lineOfSight.isTargetInSight();
    }
    private IEnumerator DelayedShot(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentAmmo--;
        Shot();
        StopCoroutine("DelayedShot");
    }
    public void Shot()
    {
        var bullet = PoolManager.Instance.INfos[2].GetProjectile();
        bullet.transform.position = transform.position;
        if (_lineOfSight.target == null)
        {
            bullet.transform.rotation = transform.rotation;
        }
        else
        {
            bullet.transform.LookAt(_lineOfSight.target.transform);
        }
    }
    protected override void Die()
    {
        EnemiesManager.Instance.enemyList.Remove(this.gameObject);
        base.Die();
    }
}
