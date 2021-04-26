using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parede : AbilityButton
{
    public override void Awake()
    {
        base.Awake();
        abilityType = AbilitySwap.AbilityType.Wall;
    }
}
