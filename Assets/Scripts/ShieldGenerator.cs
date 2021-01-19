using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShieldGenerator : Entity
{
    public GameObject[] shields;
    private new void Awake()
    {
        base.Awake();
        shields = GameObject.FindGameObjectsWithTag("Shield");
    }
    private void OnDestroy()
    {
        foreach (var item in shields)
        {
            Destroy(item);
        }
    }
}
