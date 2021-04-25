using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private AbilitySwap abilitySwap;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            abilitySwap.SetAbilityType(AbilitySwap.AbilityType.Bridge);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            abilitySwap.SetAbilityType(AbilitySwap.AbilityType.Hook);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            abilitySwap.SetAbilityType(AbilitySwap.AbilityType.Cannon);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            abilitySwap.SetAbilityType(AbilitySwap.AbilityType.Boat);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            abilitySwap.SetAbilityType(AbilitySwap.AbilityType.Wall);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            abilitySwap.SetAbilityType(AbilitySwap.AbilityType.Horn);
        }
    }

}
