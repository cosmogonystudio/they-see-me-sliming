using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : AbilityButton
{
    public override void Awake()
    {
        base.Awake();
        abilityType = AbilitySwap.AbilityType.Cannon;
    }
}
