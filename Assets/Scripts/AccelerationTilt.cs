using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationTilt : MonoBehaviour
{
    private GameObject Body;
    private PlayerController actorScript;

    //events 
    public delegate void onAcelerationStarts();
    public static event onAcelerationStarts onAcelerationStartsEvent;

    public delegate void onAcelerationStops();
    public static event onAcelerationStops onAcelerationStopsEvent;

    public delegate void onTurnStarts();
    public static event onTurnStarts onTurnSStartsEvent;

    public delegate void onTurnSStops();
    public static event onTurnSStops onTurnStopsEvent;

    float currentSpeed;
    [SerializeField]
    private float tiltSpeed;
    [SerializeField]
    private float untiltSpeed;
    [SerializeField]
    private float tiltRotation;
    [SerializeField]
    private float untiltRotation;
    [SerializeField]
    private float maxtilt;
    [SerializeField]
    private float tiltTime;

    private bool isTilting;


    // Start is called before the first frame update
    void Start()
    {
        actorScript = gameObject.GetComponent<PlayerController>();
        isTilting = false;
    }
    private void Update()
    {
        if (actorScript.Acelerating)
        {         
            actorScript.body.transform.Rotate(Vector3.right * Time.deltaTime * 3f);
        }
        else if(!actorScript.Acelerating)
        {
            isTilting = false;
            actorScript.body.transform.Rotate(Vector3.right * Time.deltaTime * -8f);
        }
    }

}
