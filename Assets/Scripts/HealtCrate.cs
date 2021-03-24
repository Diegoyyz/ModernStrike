using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtCrate : PowerUp
{
    protected override void AplyEffect(PlayerController Actor)
    {
        if (_audioSource != null)
        {
            _audioSource.Play();
        }
        Actor.heal(this.EffectAmmount);
    }
}
