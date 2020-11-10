using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float altitude;
    [SerializeField]
    private float takeofTime;
    [SerializeField]
    private float torgue;
    [SerializeField]
    private float currentStrifeSpeed;
    [SerializeField]
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
    [SerializeField]
    public bool flying;
    [SerializeField]
    private GameObject body;
    [SerializeField]
    private float tiltAmount;
    [SerializeField]
    [Range(0, 1)]
    private float tiltTime;
    private bool isStrifing;
    public bool Acelerating;
    public bool StrifeAcelerating;
    public Weapon Weapn1;
    public Weapon Weapn2;
    public Weapon Weapn3;
    private Rigidbody rb;
    private float _landingHeight;
    [SerializeField]
    private bool _isLanding;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        body.transform.SetParent(this.transform);
        isStrifing = false;
        StrifeAcelerating = false;
        _isLanding = false;
        _landingHeight = transform.position.y;
    }
    private void Update()
    {
        if (!Acelerating)
        {
            Decelerate();
        }
        if (!StrifeAcelerating)
        {
            StrifeDecelerate();
        }
        transform.position += transform.forward * currentSpeed * Time.deltaTime;
        transform.position += transform.right * currentStrifeSpeed * Time.deltaTime;

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

    public void land()
    {
        if (!_isLanding)
        {
            _isLanding = true;

            LeanTween.move(gameObject, transform.position - new Vector3(0, altitude, 0), takeofTime)
                       .setEase(LeanTweenType.easeOutCubic).
                         setOnComplete(isLanding); 
            anim.SetTrigger("Land");
            engineOff();
            flying = false;
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
            flying = true;
            engineOn();
        }
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
        Vector3 Axis = new Vector3(dir, 0, 0);

    }
    public void Reverse()
    {
        Acelerating = true;
        if (currentSpeed > -MaxSpeed)
            currentSpeed = currentSpeed - Acceleration * Time.deltaTime;
    }
    public void Accelerate()
    {
        Acelerating = true;
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
        StrifeAcelerating = true;
        if (currentStrifeSpeed < MaxStrifeSpeed)
            currentStrifeSpeed = currentStrifeSpeed + strifeaceleration *
                direction * Time.deltaTime;
    }
}
