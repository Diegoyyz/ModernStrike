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
    private bool flying;
    [SerializeField]
    private GameObject body;
    [SerializeField]
    private float tiltAmount;
    [SerializeField]
    [Range(0,1)]
    private float tiltTime;
    private bool isStrifing;
    public bool Acelerating;
    public bool StrifeAcelerating;
    public Weapon Weapn1;
    public Weapon Weapn2;
    public Weapon Weapn3;
    private Rigidbody rb;
    private float _landingHeight;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        body.transform.SetParent(this.transform);
        isStrifing = false;
        StrifeAcelerating = false;
        _landingHeight = transform.position.y;
        
    }
    private void Update()
    {   
        if (flying && Input.GetKeyDown(KeyCode.Space))
        {
            land();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !flying)
        {
            takeof();
        }
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
    IEnumerator Tilt(Vector3 axis, float angle, float duration)
    {
        Quaternion from = body.transform.rotation;
        Quaternion to = body.transform.rotation;
        to *= Quaternion.Euler(axis * angle);
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            body.transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        body.transform.rotation = to;
    }


    public void OnTurn(Vector3 dir)
    {
        Vector3 Axis = Vector3.Cross(dir.normalized, Vector3.right);
        body.transform.Rotate(Axis, tiltAmount);

    }
    public void onStopTurning(Vector3 dir)
    {
        Vector3 Axis = Vector3.Cross(dir.normalized, -Vector3.right);
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

    private void land()
    {
        LeanTween.move(gameObject, transform.position - new Vector3(0, altitude, 0), takeofTime)
                       .setEase(LeanTweenType.easeOutCubic);
        anim.SetTrigger("Land");
        engineOff();
        flying = false;
    }

    private void takeof()
    {
        LeanTween.move(gameObject, transform.position + new Vector3(0, altitude, 0), takeofTime)
                .setEase(LeanTweenType.easeInCubic);
        anim.SetTrigger("Launch");
        engineOn();
        flying = true;
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
        transform.Rotate(Vector3.up * direction * Time.deltaTime*torgue);
    }

    public void OnMove(Vector3 dir)
    {
        Vector3 Axis = Vector3.Cross(dir.normalized, Vector3.forward);
        StartCoroutine(Tilt(Axis, tiltAmount, tiltTime));
    }
    public void onStopMoving(Vector3 dir)
    {
        Vector3 Axis = Vector3.Cross(dir.normalized, Vector3.forward);
        StartCoroutine(Tilt(Axis, -tiltAmount, tiltTime));
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
            currentStrifeSpeed = currentStrifeSpeed + strifeaceleration*
                direction * Time.deltaTime;     
    }
}
