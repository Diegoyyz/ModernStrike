using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PowerUp : MonoBehaviour
{
    [SerializeField]
    protected int EffectAmmount;
    [SerializeField]
    protected AudioSource _audioSource;
private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hook"&& collision.gameObject.transform.childCount<2)
        {
            transform.SetParent(collision.gameObject.transform);
            transform.position = collision.gameObject.transform.position;
        }
        if (collision.gameObject.tag == "Player")
        {
            AplyEffect(collision.gameObject.GetComponent<PlayerController>());
            Destroy(this.gameObject, .3f);
        }
    }
    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }
    protected virtual void AplyEffect(PlayerController Actor)
    {
      
    }
}
