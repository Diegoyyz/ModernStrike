using Assets.Scripts.FSM.EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : Entity
{
    public GameObject deathDrop;
    public EnemyIDEnum iD;
    [SerializeField]
    private float maxDistToTarget;
    [SerializeField]
    protected EnemyState currentState;
    [SerializeField]
    protected int maxAmmo;
    [SerializeField]
    [Range(1f, 5)]
    public float fireRate; 
    protected int currentAmmo;
    private new void Awake()
    {
        base.Awake();
        currentAmmo = maxAmmo;
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }
    public void Update()
    {        
        if (currentHp <= 0)
        {
            Die();
        }
    }
    
    public bool TargetOnShotDistanse()
    {
        if (_lineOfSight.distToTarget() <= _lineOfSight.shootingDistance)
            return true;
        else return false;
    }
    protected override void Die()
    {
        if (deathDrop!=null)
        {
            var toSpawn = Instantiate(deathDrop);
            toSpawn.transform.position = transform.position;
            toSpawn.transform.rotation = Quaternion.identity;
        }
        EventManager.EnemyDied(iD);
        Destroy(this.gameObject);
    }
   
    public void SetState(EnemyState state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        gameObject.name = "Enemy Eoldier- " + state.GetType().Name;
        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }    
}
