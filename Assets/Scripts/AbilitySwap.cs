using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySwap : MonoBehaviour {

    public enum AbilityType
    {
        Horn, // Apito
        Wall,
        Bridge,
        Hook,
        Cannon,
        Boat
    }

    public void SetAbilityType(AbilityType abilityType)
    {
        switch (abilityType) {
            default:
            case AbilityType.Bridge:
                break;
            case AbilityType.Hook:
                break;
            case AbilityType.Cannon:
                break;
            case AbilityType.Boat:
                break;
            case AbilityType.Wall:
                break;
            case AbilityType.Horn:
                break;
        }
    }
}

public interface IAbility
{
    void useAbility(Vector2 position);
}

public class Bridge : MonoBehaviour, IAbility
{
    public GameObject bridge;
    public void useAbility(Vector2 position)
    {
        Instantiate(bridge, position, Quaternion.identity);
    }
}

public class Hook : MonoBehaviour, IAbility
{
    public GameObject hook;
    public void useAbility(Vector2 position)
    {
        Instantiate(hook, position, Quaternion.identity);
    }
}

public class Cannon : MonoBehaviour, IAbility
{
    public GameObject cannon;
    public void useAbility(Vector2 position)
    {
        Instantiate(cannon, position, Quaternion.identity);

        // Destroi
        // Constroi um cannon
        // Outro
    }
}

public class Boat : MonoBehaviour, IAbility
{
    public GameObject boat;
    public void useAbility(Vector2 position)
    {
        Instantiate(boat, position, Quaternion.identity);

        // Clica no bote
        // Clica no slime - equipar bote
        // Morre na água
        // Espera a galera subir

        // Amortece a queda
    }
}

public class Wall : MonoBehaviour, IAbility
{
    public GameObject wall;
    public void useAbility(Vector2 position)
    {
        Instantiate(wall, position, Quaternion.identity);
    }
}

public class Horn : MonoBehaviour, IAbility
{
    public void useAbility(Vector2 position)
    {
    }
}
