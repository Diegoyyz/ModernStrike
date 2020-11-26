﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float altitude;
    [SerializeField]
    private float landDistance;
    [SerializeField]
    private float takeofTime;
    [SerializeField]
    private float torgue;
    private float currentStrifeSpeed;
    private float currentSpeed;
    [SerializeField]
    private float strifeaceleration;
    [SerializeField]
    private float MaxSpeed = 10;
    [SerializeField]
    private float MaxStrifeSpeed = 10;
    [SerializeField]
    private float Acceleration = 10;
    [SerializeField]
    private float Deceleration = 10;
    private Animator anim;
    private bool _flying;
    public GameObject body;
    [SerializeField]
    private float tiltAmount;
    [SerializeField]
    [Range(0, 1)]
    private float tiltTime;
    private bool isStrifing;
    private bool _acelerating;
    private bool _strifeAcelerating;
    public Weapon Weapn1;
    public Weapon Weapn2;
    public Weapon Weapn3;
    private Rigidbody rb;
    private float _landingHeight;
    private bool _isLanding;
    [SerializeField]
    private GameObject hook;
    [SerializeField]
    private float HookAltitude;
    [SerializeField]
    private float HookDowntime;
    public bool isHookDown;
    [SerializeField]
    public float maxHp;
    [SerializeField]
    private float _currentHp;
    [SerializeField]
    private float _currentFuel;
    [SerializeField]
    public float maxFuel;
    [SerializeField]
    [Range(0.5f,2)]
    private float fuelCconRate;
    private bool _onLandingZone;
    private Transform landingZone;

    public delegate void GetCargo();
    public static event GetCargo OnGetCargo;

    private void OnEnable()
    {
        OnGetCargo += () => { };
    }
    public float CurrentHealt
    {
        get
        {
            return _currentHp;
        }
        set
        {
            _currentHp = value;
        }
    }
    public float CurrentFuel
    {
        get
        {
            return _currentFuel;
        }
        set
        {
            _currentFuel = value;
        }
    }

    public void heal(int Amount)
    {
        _currentHp += Amount;
    }
    public void chargeFuel(int Amount)
    {
        _currentFuel += Amount;
    }
    private void Awake()
    {
      
        currentSpeed = maxHp;
        CurrentFuel = maxFuel;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        body.transform.SetParent(this.transform);
        isStrifing = false;
        _strifeAcelerating = false;
        _isLanding = false;
        _landingHeight = transform.position.y;
    }
    private void Update()
    {
        if (!_acelerating)
        {
            Decelerate();
        }
        else
        {
         _currentFuel -= fuelCconRate * Time.deltaTime;

        }
        if (!_strifeAcelerating)
        {
            StrifeDecelerate();
        }
        else
        {
            _currentFuel -= fuelCconRate * Time.deltaTime;
        }
        transform.position += transform.forward * currentSpeed * Time.deltaTime;
        transform.position += transform.right * currentStrifeSpeed * Time.deltaTime;
    }

    public bool Flying
    {
        get { return _flying; }
        set { _flying = value; }
    }
    public bool Accelerating
    {
        get { return  _acelerating; }
        set { _acelerating = value; }
    }
    public bool StrifeAccelerating
    {
        get { return _acelerating; }
        set { _acelerating = value; }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LandingZone")
        {
            _onLandingZone = true;
            landingZone = collision.gameObject.transform;
        }
        if (collision.gameObject.tag == "Ally")
        {
            OnGetCargo();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "LandingZone")
        {
            _onLandingZone = false;
            landingZone = null;

        }
    }

    public void OnTurn(float dir)
    {
        Vector3 Axis = new Vector3(0, 0, dir);
        body.transform.Rotate(Axis, tiltAmount);
    }
    public void onStopTurning(float dir)
    {
        Vector3 Axis = new Vector3(dir, 0, 0);
        body.transform.Rotate(Axis, tiltAmount);
    }
    public void OnStopMovingBW()
    {
        body.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    public void OnStopMovingFW()
    {
        body.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    public void hookDown()
    {
        if (!_isLanding)
        {         
            LeanTween.moveLocalY(hook,-HookAltitude, HookDowntime).setEase(LeanTweenType.easeInCubic).
           setOnComplete(IsHookDown);
        }
       
    }
    public void hookUp()
    {
        if (!_isLanding)
        {
            LeanTween.moveLocalY(hook, -0.72f, HookDowntime).setEase(LeanTweenType.easeOutCubic).
            setOnComplete(IsHookDown);
        }
    }
    public void land()
    {
        if (!_isLanding&& _onLandingZone&& landingZone!= null)
        {
            _isLanding = true;
            LeanTween.move(gameObject, landingZone.position - new Vector3(0, landDistance, 0), takeofTime)
                       .setEase(LeanTweenType.easeOutCubic).
                         setOnComplete(isLanding); 
            anim.SetTrigger("Land");
            engineOff();
            _flying = false;
        }
    }
    public void takeof()
    {
        if (!_isLanding)
        {
            _isLanding = true;
            LeanTween.move(gameObject, transform.position + new Vector3(0, altitude, 0), takeofTime)
                .setEase(LeanTweenType.easeInCubic).
                setOnComplete(isLanding);
            anim.SetTrigger("Launch");
            _flying = true;
            engineOn();
        }
    }


   

    public void IsHookDown()
    {
        if (isHookDown)
            isHookDown = false;
        else isHookDown = true;
    }
    public void isLanding()
    {
        if (_isLanding)
            _isLanding = false;
        else _isLanding = true;
    }
    private void engineOn()
    {
        anim.SetBool("EngineOn", true);
    }
    private void engineOff()
    {
        anim.SetBool("EngineOn", false);
    }
    public void Turn(int direction)
    {
        transform.Rotate(Vector3.up * direction * Time.deltaTime * torgue);
    }
    public void onStopMoving(float dir)
    {


    }
    public void Reverse()
    {
        _acelerating = true;
        if (currentSpeed > -MaxSpeed)
            currentSpeed = currentSpeed - Acceleration * Time.deltaTime;
    }
    public void Accelerate()
    {
        _acelerating = true;
        if (currentSpeed < MaxSpeed)
            currentSpeed = currentSpeed + Acceleration * Time.deltaTime;
    }
    public void Decelerate()
    {
        if (currentSpeed > Deceleration * Time.deltaTime)
            currentSpeed = currentSpeed - Deceleration * Time.deltaTime;
        else if (currentSpeed < -Deceleration * Time.deltaTime)
            currentSpeed = currentSpeed + Deceleration * Time.deltaTime;
        else
            currentSpeed = 0;
    }
    public void StrifeDecelerate()
    {
        if (currentStrifeSpeed > strifeaceleration * Time.deltaTime)
            currentStrifeSpeed = currentStrifeSpeed - strifeaceleration * Time.deltaTime;
        else if (currentStrifeSpeed < -strifeaceleration * Time.deltaTime)
            currentStrifeSpeed = currentStrifeSpeed + strifeaceleration * Time.deltaTime;
        else
            currentStrifeSpeed = 0;
    }
    public void Strife(float direction)
    {
        _strifeAcelerating = true;
        if (currentStrifeSpeed < MaxStrifeSpeed)
            currentStrifeSpeed = currentStrifeSpeed + strifeaceleration *
                direction * Time.deltaTime;
    }
}
