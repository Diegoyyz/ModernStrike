using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    protected int maxHp;
    [SerializeField]
    protected int currentHp;
    [SerializeField]
    protected float Speed;
    [SerializeField]
    protected GameObject Target;
    protected Animator Anim;


    private void Awake()
    {
        currentHp = maxHp;
    }
    private void Update()
    {
       
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
