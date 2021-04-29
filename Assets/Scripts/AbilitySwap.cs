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

    private int defaultLayer;

    private Vector2 boatSize = new Vector2(4.85f, 1.6f);

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

        AudioManager.GetInstance().PlayAbility(currentAbilityType);

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

    void Awake()
    {
        defaultLayer = LayerMask.NameToLayer("Default");
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

        currentSlime.GetComponent<CapsuleCollider2D>().enabled = false;
        currentSlime.GetComponent<PolygonCollider2D>().enabled = true;

        currentSlime.GetComponent<Rigidbody2D>().mass = 1f * 1000f;
    }

    private void UseHook()
    {
        currentSlime.Crafted(AbilityType.Hook);

        Craft(currentSlime.gameObject);

        currentSlime.GetComponent<Rigidbody2D>().Sleep();

        Debug.Log("TODO");
    }

    private void UseCannon()
    {
        currentSlime.Crafted(AbilityType.Cannon);

        Craft(currentSlime.gameObject);

        currentSlime.GetComponent<Rigidbody2D>().Sleep();

        currentSlime.GetComponent<CapsuleCollider2D>().enabled = false;
        BoxCollider2D boxCollider2D = currentSlime.GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = true;
        boxCollider2D.isTrigger = true;

        currentSlime.gameObject.AddComponent<CannonAbility>();
    }

    private void UseBoat()
    {
        currentSlime.Crafted(AbilityType.Boat);

        Craft(currentSlime.gameObject);

        CapsuleCollider2D capsuleCollider2D = currentSlime.GetComponent<CapsuleCollider2D>();
        capsuleCollider2D.direction = CapsuleDirection2D.Horizontal;
        capsuleCollider2D.size = boatSize;

        currentSlime.GetComponent<Rigidbody2D>().mass = 10f * 1000f;

        currentSlime.gameObject.AddComponent<Boat>();
    }

    private void UseWall()
    {
        currentSlime.Crafted(AbilityType.Wall);

        Craft(currentSlime.gameObject);

        currentSlime.GetComponent<CapsuleCollider2D>().enabled = false;
        currentSlime.GetComponent<BoxCollider2D>().enabled = true;

        currentSlime.GetComponent<Rigidbody2D>().mass = 100f * 1000f;

        currentSlime.gameObject.AddComponent<Block>();
    }

    private void UseHorn(List<Slime> ableSlimes)
    {
        AudioManager.GetInstance().PlayStatus(Slime.SlimeStatus.Paused);

        ableSlimes.ForEach(slime => slime.Pause());

        StartCoroutine(OnHorn(currentSlime, ableSlimes));
    }

    private void Craft(GameObject slimeGameObject)
    {
        slimeGameObject.tag = untaggedTag;
        slimeGameObject.layer = defaultLayer;
        slimeGameObject.GetComponent<Slime>().enabled = false;
        slimeGameObject.GetComponent<SlimeCheckGround>().enabled = false;
    }

}
