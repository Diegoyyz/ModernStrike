using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtCrate : PowerUp
{
    protected override void AplyEffect(PlayerController Actor)
    {
        Actor.heal(this.EffectAmmount);
    }
}
