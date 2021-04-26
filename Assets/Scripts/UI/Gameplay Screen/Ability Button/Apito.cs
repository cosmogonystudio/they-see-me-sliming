using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Apito : AbilityButton
{
    public override void Awake()
    {
        base.Awake();
        abilityType = AbilitySwap.AbilityType.Horn;
    }
}
