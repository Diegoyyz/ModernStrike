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
    private void Update() { 
        Debug.Log(actorScript.body.transform.rotation);

        if (actorScript.Acelerating&& actorScript.body.transform.rotation.x<0.06f)
        {
            isTilting = true;
            actorScript.body.transform.localRotation *= Quaternion.AngleAxis(tiltSpeed * Time.deltaTime, actorScript.transform.right);

        }
        else if(!actorScript.Acelerating && actorScript.body.transform.rotation.x !=0)
        {
            isTilting = false;
            actorScript.body.transform.localRotation *= Quaternion.AngleAxis(-untiltSpeed * Time.deltaTime, actorScript.transform.right);
        }
    }

}
