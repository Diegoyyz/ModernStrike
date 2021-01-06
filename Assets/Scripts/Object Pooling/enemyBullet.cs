using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyBullet : Projectile
{
    public TrailRenderer trail;
    private float _tick;
    private bool _alive;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Entity>().TakeDmg(dmg);
            DisposeProjectile(this);
        }
    }
    public override void Move()
    {
        _tick += Time.deltaTime;
        if (_tick >= lifeSpan)
        {
            PoolManager.Instance.INfos[2].ReturnObjectToPool(this);
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
