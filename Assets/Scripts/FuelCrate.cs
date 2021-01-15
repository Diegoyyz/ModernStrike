using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCrate : PowerUp
{    protected override void AplyEffect(PlayerController Actor)
    {
        Actor.heal(EffectAmmount);
    }
}
