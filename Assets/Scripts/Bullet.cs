using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : Projectile
{
    public TrailRenderer trail;
    private float _tick;
    private bool _alive;
    [SerializeField]
    private GameObject onHitEffect;
    public override void Move()
    {
        _tick += Time.deltaTime;
        if (_tick >= lifeSpan)
        {
            PoolManager.Instance.INfos[0].ReturnObjectToPool(this);
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        var hit = Instantiate(onHitEffect);
        hit.transform.position = transform.position;
        Destroy(hit, 2);
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Entity>().TakeDmg(dmg);
        }
        DisposeProjectile(this);


    }
    public override void Dispose()
    {
        trail.time = 0;
    }
    public override void Initialize()
    {
        base.Initialize();
        _tick = 0;
        transform.position = Vector3.zero;
        trail.time = 0.3f;
    }
}
