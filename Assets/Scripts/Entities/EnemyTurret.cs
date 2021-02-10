using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyTurret : Enemy
{
    [SerializeField]
    private Image HealtBar;
   
    private new void Awake()
    {
        base.Awake();
        SetState(new IdleTurretState(this));
    }   
    private new void Update()
    {        
        base.Update();
        currentState.Tick();
        HealtBar.fillAmount = HealtPorcentage();
        targetInSight = _lineOfSight.isTargetInSight();
    }
    public float HealtPorcentage()
    {
        return currentHp / maxHp;
    }
    public void aimToTarget()
    {
        transform.LookAt(_lineOfSight.target);
    }  

}
