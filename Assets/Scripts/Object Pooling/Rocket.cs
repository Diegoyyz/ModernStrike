using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Projectile
{
    private float _tick;
    private bool _alive;   
    [SerializeField]
    private float explosionRadius;
    [SerializeField]
    private int explosionDmg;
    public override void Dispose()
    {

    }

    private void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Enemy" && hitCollider.gameObject != null)
            {
                hitCollider.gameObject.GetComponent<Entity>().TakeDmg(explosionDmg);
            }
        }
    }
    private void OnCollisionEnter(Collision Other)
    {
        DisposeProjectile(this);
        if (Other.gameObject.tag=="Enemy")
        {
            Other.gameObject.GetComponent<Entity>().TakeDmg(dmg);
        }
        ExplosionDamage(transform.position, explosionRadius);

    }
    public override void Move()
    {
        _tick += Time.deltaTime;
        if (_tick >= lifeSpan)
        {
            PoolManager.Instance.INfos[1].ReturnObjectToPool(this);
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
    public override void Initialize()
    {
        base.Initialize();
        _tick = 0;
        transform.position = Vector3.zero;
    }
}
