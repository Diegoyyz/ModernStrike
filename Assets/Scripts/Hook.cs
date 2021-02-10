using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hook : MonoBehaviour
{
    public delegate void getHookUp();
    public static event getHookUp onGetHookUp;
    [SerializeField]
    private float hookdowntime;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            onGetHookUp();
        }
        if (collision.gameObject.tag == "Ally" )
        {
            onGetHookUp();
        }
    }   
}
