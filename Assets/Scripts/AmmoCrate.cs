using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : PowerUp
{
    protected override void AplyEffect(PlayerController Actor)
    {
        Actor.Weapn1.rechargeAmmo(EffectAmmount);
        if (_audioSource != null)
        {
            _audioSource.Play();
        }
        Actor.Weapn2.rechargeAmmo(EffectAmmount / 2);
        if (Actor.Weapn3 != null)
        {
            Actor.Weapn2.rechargeAmmo(1);
        }
    }
}
