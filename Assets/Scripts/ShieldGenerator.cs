using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShieldGenerator : Entity
{
    public List<GameObject> shields;

    [SerializeField]
    private float influenceDist;
    private new void Awake()
    {
        base.Awake();
        shields = GameObject.FindGameObjectsWithTag("Shield").Where(x=> Vector3.Distance(x.transform.position, transform.position) < influenceDist).ToList();
    }
    private void OnDestroy()
    {
        foreach (var item in shields)
        {
            Destroy(item);
        }
    }
    private void findClosest(List<GameObject> shields)
    {
        foreach (var item in shields)
        {
            if (Vector3.Distance(item.transform.position, transform.position)>influenceDist)
            {
                shields.Remove(item);
                Debug.Log("retirar");
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, influenceDist);
    }
}
