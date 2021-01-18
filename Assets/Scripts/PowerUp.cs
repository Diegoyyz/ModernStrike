using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    protected int EffectAmmount;
private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hook")
        {
            transform.SetParent(collision.gameObject.transform);
            transform.position = collision.gameObject.transform.position;
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            AplyEffect(collision.gameObject.GetComponent<PlayerController>());
        }

    }
    protected virtual void AplyEffect(PlayerController Actor)
    {

    }
}
