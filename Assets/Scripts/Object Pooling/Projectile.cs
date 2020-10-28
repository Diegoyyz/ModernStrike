using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float lifeSpan;
    [SerializeField]
    protected int dmg;

    private void Update()
    {
        Move();
    }
    public virtual void Move()
    {
        
    }
   

    public static void InitializeProjectile(Projectile ProjectileObj)
    {
        ProjectileObj.gameObject.SetActive(true);
        ProjectileObj.Initialize();
    }
    public virtual void Dispose()
    {
    }
    public static void DisposeProjectile(Projectile ProjectileObj)
    {
        ProjectileObj.Dispose();
        ProjectileObj.gameObject.SetActive(false);
    }
    public virtual void Initialize()
    {

    }
    
}
