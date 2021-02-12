using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : Entity
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
    private Crane crane;   
    [SerializeField]
    private float _currentFuel;
    [SerializeField]
    public float maxFuel;
    [SerializeField]
    [Range(0.5f, 2)]
    private float fuelCconRate;
    [SerializeField]
    private bool _onLandingZone;
    private Transform landingZone;
    [SerializeField]
    private int maxCargo;
    private int currentCargo;
    public delegate void GetCargo();
    public static event GetCargo OnGetCargo;
    public delegate void discharge();
    public static event discharge OnDisharge;
    public delegate void dieEvent();
    public static event dieEvent OnDie;


    private void OnEnable()
    {
        OnGetCargo += incCargo;
        OnDisharge += DisCharge;   
    }
    public void incCargo()
    {
        currentCargo++;
    }
    public float CurrentHealt
    {
        get
        {
            return currentHp;
        }
        set
        {
            currentHp = value;
        }
    }
    public float HealtPorcentage()
    {
        return CurrentHealt / maxHp;

    }
    public float FuelPorcentage()
    {
        return CurrentFuel / maxFuel;
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
        currentHp += Amount;
    }
    public void chargeFuel(int Amount)
    {
        _currentFuel += Amount;
    }
    private new void Awake()
    {
        base.Awake();
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
        if (currentHp <= 0)
        {
            OnDie();
        }
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
        get { return _acelerating; }
        set { _acelerating = value; }
    }
    public bool StrifeAccelerating
    {
        get { return _strifeAcelerating; }
        set { _strifeAcelerating = value; }
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
    }
    public void onStopTurning(float dir)
    {
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
        if (!_isLanding && _onLandingZone && landingZone != null)
        {
            _isLanding = true;
            LeanTween.move(gameObject, landingZone.position - new Vector3(0, landDistance, 0), takeofTime)
                       .setEase(LeanTweenType.easeOutCubic).
                         setOnComplete(isLanding);
            anim.SetTrigger("Land");
            engineOff();
            _flying = false;
            OnDisharge();
        }
    }
    private void DisCharge()
    {
        for (int i = 0; i < currentCargo; i++)
        {
            EventManager.ItemGrabbed(1);
        }
        currentCargo = 0;
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
            currentStrifeSpeed = currentStrifeSpeed - Deceleration * Time.deltaTime;
        else if (currentStrifeSpeed < -strifeaceleration * Time.deltaTime)
            currentStrifeSpeed = currentStrifeSpeed + Deceleration * Time.deltaTime;
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
