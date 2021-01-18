using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShieldGenerator : Entity
{
    private GameObject[] shields;
    private new void Awake()
    {
        base.Awake();
        shields = GameObject.FindGameObjectsWithTag("Shields");

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
