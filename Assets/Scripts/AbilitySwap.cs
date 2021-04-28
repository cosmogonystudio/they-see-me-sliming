using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySwap : MonoBehaviour
{

    public enum AbilityType
    {
        Bridge,
        Hook,
        Cannon,
        Boat,
        Wall,
        Horn,

        None
    }

    public const string untaggedTag = "Untagged";

    [SerializeField]
    private float pauseSeconds;

    private AbilityType currentAbilityType = AbilityType.None;
    private Slime currentSlime = null;
    private bool currentUsing = false;

    private int defaultLayer = LayerMask.NameToLayer("Default");

    public AbilityType GetCurrentAbilityType()
    {
        return currentAbilityType;
    }

    public void SetAbilityType(AbilityType abilityType)
    {
        currentAbilityType = abilityType;
    }

    public void UseAbility(Slime slime)
    {
        if (currentUsing == true || 
            (
                currentAbilityType == AbilityType.None ||
                currentAbilityType == AbilityType.Cannon
            ))
        {
            return;
        }

        currentUsing = true;
        currentSlime = slime;

        slime.Use(currentAbilityType);
    }

    public void OnAbilityUse(List<Slime> ableSlimes)
    {
        if (currentUsing == false)
        {
            return;
        }

        ableSlimes.Remove(currentSlime);

        switch (currentAbilityType)
        {
            case AbilityType.Bridge:
                UseBridge();
                break;
            case AbilityType.Hook:
                UseHook();
                break;
            case AbilityType.Cannon:
                UseCannon();
                break;
            case AbilityType.Boat:
                UseBoat();
                break;
            case AbilityType.Wall:
                UseWall();
                break;
            case AbilityType.Horn:
                UseHorn(ableSlimes);
                break;
            default:
                break;
        }

        currentUsing = false;
    }

    IEnumerator OnHorn(Slime slime, List<Slime> ableSlimes)
    {
        yield return new WaitForSeconds(pauseSeconds);

        slime.KeepWalking();

        ableSlimes.ForEach(slime =>
        {
            if (slime.GetSlimeStatus() == Slime.SlimeStatus.InAir)
            {
                slime.Fall();
            }
            else
            {
                slime.KeepWalking();
            }
        });
    }

    private void UseBridge()
    {
        currentSlime.Crafted(AbilityType.Bridge);

        Craft(currentSlime.gameObject);

        // TODO
    }

    private void UseHook()
    {
        currentSlime.GetComponent<Rigidbody2D>().Sleep();

        currentSlime.Crafted(AbilityType.Hook);

        Debug.Log("UseHook()");
    }

    private void UseCannon()
    {
        Debug.Log("UseCannon()");
    }

    private void UseBoat()
    {
        currentSlime.Crafted(AbilityType.Boat);

        Craft(currentSlime.gameObject);

        currentSlime.gameObject.AddComponent<Boat>();
    }

    private void UseWall()
    {
        currentSlime.Crafted(AbilityType.Wall);

        Craft(currentSlime.gameObject);

        currentSlime.gameObject.AddComponent<Block>();
    }

    private void UseHorn(List<Slime> ableSlimes)
    {
        ableSlimes.ForEach(slime => slime.Pause());

        StartCoroutine(OnHorn(currentSlime, ableSlimes));
    }

    private void Craft(GameObject slimeGameObject)
    {
        slimeGameObject.tag = untaggedTag;
        slimeGameObject.layer = defaultLayer;
        slimeGameObject.GetComponent<Slime>().enabled = false;
        slimeGameObject.GetComponent<SlimeCheckGround>().enabled = false;
        slimeGameObject.GetComponent<Rigidbody2D>().mass = 1000f;
    }

}
