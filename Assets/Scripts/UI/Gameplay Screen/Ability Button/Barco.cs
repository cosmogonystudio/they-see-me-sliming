using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barco : AbilityButton
{
    public override void Awake()
    {
        base.Awake();
        abilityType = AbilitySwap.AbilityType.Boat;
    }
}
