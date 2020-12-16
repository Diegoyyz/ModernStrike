using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    protected virtual void Awake()
    {
        _lineOfSight = GetComponent<LineOfSight>();
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
}
