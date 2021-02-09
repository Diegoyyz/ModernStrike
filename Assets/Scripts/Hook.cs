using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public delegate void getHookUp();
    public static event getHookUp onGetHookUp;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            onGetHookUp();
        }
        if (collision.gameObject.tag == "Ally" )
        {
            onGetHookUp();
            Debug.Log("parribabo");
        }
    }
}
