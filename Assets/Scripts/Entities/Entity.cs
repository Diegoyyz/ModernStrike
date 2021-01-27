using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Entity : MonoBehaviour
{
    [SerializeField]
    protected float maxHp;
    public Vector3 homePos;
    protected float currentHp;
    [SerializeField]
    protected float speed;
    protected Animator Anim;
    [SerializeField]
    public bool targetInSight;
    protected LineOfSight _lineOfSight;
    [SerializeField]
    protected NavMeshAgent agent;

    protected virtual void Awake()
    {
        _lineOfSight = GetComponent<LineOfSight>();
        agent = GetComponent<NavMeshAgent>();        
        currentHp = maxHp;
    }
    public void moveTowardTarget()
    {
        agent.SetDestination(_lineOfSight.target.transform.position);
    }
    public void moveTowardHome()
    {
        agent.SetDestination(homePos);
    }
    public void TakeDmg(int dmg)
    {
        currentHp -= dmg;
    }
    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }    

}
