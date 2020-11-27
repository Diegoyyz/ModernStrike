using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

[Serializable]
public class PoolInfo
{
    public String ID;
    public Projectile Prefab;
    public int amount;
    public Pool<Projectile> Pool;
    public Projectile Factory()
    {
        return GameObject.Instantiate(Prefab);
    }
    public Projectile GetProjectile()
    {
        return Pool.GetObjectFromPool();
    }
    public void ReturnObjectToPool(Projectile obj)
    {
        Pool.DisablePoolObject(obj);
    }
}

public class PoolManager : MonoBehaviour
{
    private static PoolManager _instance;
    public static PoolManager Instance { get { return _instance; } }
    [SerializeField]
    public List<PoolInfo> INfos =new List<PoolInfo>();
    private int current;
  
    private void OnEnable()
    {
        
        _instance = this;
        CreatePools();
    }
    private void CreatePools()
    {
        for (int i = 0; i < INfos.Count; i++)
        {         
            INfos[i].Pool = new Pool<Projectile>(INfos[i].amount, INfos[i].Factory, Projectile.InitializeProjectile, Projectile.DisposeProjectile, true);
            current = i;
        }
    }
}

