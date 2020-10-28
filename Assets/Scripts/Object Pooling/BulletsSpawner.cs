using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BulletsSpawner : MonoBehaviour 
{
    [SerializeField]
    private Bullet bulletPrefab;
    private Pool<Projectile> _bulletPool;
    private float nextShot;
    [SerializeField]
    [Range(0,1)]
    private float fireRate;
    private int counter = 0;
    [SerializeField]
    private int magazineAmmo;
    private static BulletsSpawner _instance;
    public static BulletsSpawner Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
        _bulletPool = new Pool<Projectile>(8, BulletFactory, Projectile.InitializeProjectile, Projectile.DisposeProjectile, true);
    }

    private void Update () 
    {
        if (Input.GetKey(KeyCode.Z))
        {
            StartCoroutine("DelayedShot", fireRate);
        }

    }

    private IEnumerator DelayedShot(float delay)
    {
        yield return new WaitForSeconds(delay);
        counter++;
        MachingunShot();
        StopCoroutine("DelayedShot");
    }

    private void MachingunShot()
    {
        var bullet = _bulletPool.GetObjectFromPool();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
    }
    private Projectile BulletFactory()
    {

        return Instantiate<Projectile>(bulletPrefab);
    }

    public void ReturnObjectToPool(Projectile projectible)
    {
        _bulletPool.DisablePoolObject(projectible);
    }
}
