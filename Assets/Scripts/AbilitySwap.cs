using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySwap : MonoBehaviour
{

    public enum AbilityType
    {
        None,
        Bridge,
        Hook,
        Cannon,
        Boat,
        Wall,
        Horn
    }

    [SerializeField]
    private LayerMask defaultLayer;

    [SerializeField]
    private float pauseSeconds;

    private AbilityType currentAbilityType = AbilityType.None;
    private Slime currentSlime;
    private bool currentUsing = false;

    public void SetAbilityType(AbilityType abilityType)
    {
        currentAbilityType = abilityType;
    }

    public void UseAbility(Slime slime)
    {
        if (currentUsing == true || currentAbilityType == AbilityType.None)
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

        ableSlimes.ForEach(slime => {
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
        currentSlime.Crafted(AbilityType.Bridge); //, false);

        GameObject slimeGameObject = currentSlime.gameObject;

        /*
        slimeGameObject.tag = Slime.floorTag;
        slimeGameObject.layer = 7;
        slimeGameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        slimeGameObject.GetComponent<PolygonCollider2D>().enabled = true;
        slimeGameObject.GetComponent<Rigidbody2D>().mass = 1000f;
        slimeGameObject.GetComponent<Slime>().enabled = false;
        */
    }

    private void UseHook()
    {
        currentSlime.Crafted(AbilityType.Hook);

        // TODO!
    }

    private void UseCannon()
    {
        currentSlime.Crafted(AbilityType.Cannon);

        // TODO!
    }
    private void UseBoat()
    {
        currentSlime.Crafted(AbilityType.Boat);

        GameObject slimeGameObject = currentSlime.gameObject;

        slimeGameObject.tag = "Boat";
        slimeGameObject.layer = LayerMask.NameToLayer("Boat");
        slimeGameObject.GetComponent<Collider2D>().isTrigger = false;
        slimeGameObject.AddComponent<Boat>();
    }

    private void UseWall()
    {
        currentSlime.Crafted(AbilityType.Wall, false);

        GameObject slimeGameObject = currentSlime.gameObject;

        slimeGameObject.tag = "Untagged";
        slimeGameObject.layer = defaultLayer;
        Collider2D slimeCollider = slimeGameObject.GetComponent<Collider2D>();
        slimeCollider.isTrigger = true;
        slimeCollider.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        slimeGameObject.GetComponent<Slime>().enabled = false;
        slimeGameObject.AddComponent<Block>();
    }

    private void UseHorn(List<Slime> ableSlimes)
    {
        ableSlimes.ForEach(slime => slime.Pause());

        StartCoroutine(OnHorn(currentSlime, ableSlimes));
    }

}
