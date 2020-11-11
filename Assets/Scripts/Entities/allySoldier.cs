using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allySoldier : Entity
{
    [SerializeField]
    private AllySoldierState currentState;
    [SerializeField]
    private float pickUpDistance;
    public override void Awake()
    {
        base.Awake();
        homePos = transform.position;
        targetInSight = _lineOfSight.isTargetInSight();
        SetState(new IdleAsState(this));
    }
    public void SetState(AllySoldierState state)
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
    public void Update()
    {
        currentState.Tick();
        targetInSight = _lineOfSight.isTargetInSight();
    }
    public bool targetOnPickupDistanse()
    {
        if (_lineOfSight.distToTarget() <= pickUpDistance)
            return true;
        else return false;
    }
}
