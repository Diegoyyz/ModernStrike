using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{


    [SerializeField]
    public List<GameObject> enemyList = new List<GameObject>();
    private static EnemiesManager _instance;
    public static EnemiesManager Instance { get { return _instance; } }
    private void Awake()
    {
        _instance = this;
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (var item in enemies)
        {
            enemyList.Add(item.gameObject);
        }
    }

}
