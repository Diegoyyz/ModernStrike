﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    public delegate void getHookDown();
    public static event getHookDown onGetHookDown;
    public delegate void getHookUp();
    public static event getHookDown onGetHookUp;
    [SerializeField]
    private float HookAltitude;
    [SerializeField]
    private float HookDowntime;
    [SerializeField]
    private Hook hook;
    public float waittime;
    public float timeRemaining;
    public bool isHookDown;
    private void OnEnable()
    {
        isHookDown = false;
        Hook.onGetHookUp += hookUp;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUp"|| other.gameObject.tag == "Ally"&& !isHookDown)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            timeRemaining = waittime;
            hookDown();
        }
    }
    void Update()
    {
        if (timeRemaining > 0 && isHookDown)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if(timeRemaining <=0)
        {
            timeRemaining = waittime;
            hookUp();
        }
    }   

    public void hookUp()
    {        
            LeanTween.moveLocalY(hook.gameObject, -0.72f, HookDowntime).setEase(LeanTweenType.easeOutCubic).setOnComplete(IsHookDown);

    }
    public void hookDown()
    {       
            LeanTween.moveLocalY(hook.gameObject, -HookAltitude, HookDowntime).setEase(LeanTweenType.easeInCubic).setOnComplete(IsHookDown);
        
    }
    public void IsHookDown()
    {
        if (isHookDown)
            isHookDown = false;
        else isHookDown = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}