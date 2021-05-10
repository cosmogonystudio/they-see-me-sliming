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

    [SerializeField]
    private PhysicsMaterial2D bouncyMaterial;

    private AbilityType currentAbilityType = AbilityType.None;
    private Slime currentSlime = null;
    private bool currentUsing = false;

    private int defaultLayer;
    private int floorLayer;

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

    void Awake()
    {
        defaultLayer = LayerMask.NameToLayer("Default");
        floorLayer = LayerMask.NameToLayer("Floor");
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

        currentSlime.gameObject.tag = untaggedTag;
        currentSlime.gameObject.layer = floorLayer;

        currentSlime.transform.localScale = new Vector3(
            currentSlime.transform.localScale.x * 1.5f,
            currentSlime.transform.localScale.y,
            currentSlime.transform.localScale.z
        );

        currentSlime.GetComponent<Slime>().enabled = false;
        currentSlime.GetComponent<SlimeCheckGround>().enabled = false;

        currentSlime.GetComponent<CapsuleCollider2D>().enabled = false;
        currentSlime.GetComponent<PolygonCollider2D>().enabled = true;

        currentSlime.GetComponent<Rigidbody2D>().mass = 1f * 1000f;
    }

    private void UseHook()
    {
        currentSlime.Crafted(AbilityType.Hook);

        Craft(currentSlime.gameObject);

        currentSlime.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        currentSlime.GetComponent<CapsuleCollider2D>().isTrigger = true;
    }

    private void UseCannon()
    {
        currentSlime.Crafted(AbilityType.Cannon);

        Craft(currentSlime.gameObject);

        currentSlime.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        currentSlime.GetComponent<CapsuleCollider2D>().enabled = false;
        BoxCollider2D boxCollider2D = currentSlime.GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = true;
        boxCollider2D.isTrigger = true;

        currentSlime.transform.Translate(0.15f * Vector3.down);

        CannonAbility cannonAbility = currentSlime.gameObject.AddComponent<CannonAbility>();
        cannonAbility.reach = 6f;
        cannonAbility.height = 2f;
        cannonAbility.launchSpeed = 1f;
    }

    private void UseBoat()
    {
        currentSlime.Crafted(AbilityType.Boat);

        currentSlime.GetComponent<Slime>().enabled = false;
        currentSlime.GetComponent<SlimeCheckGround>().enabled = false;

        CapsuleCollider2D capsuleCollider2D = currentSlime.GetComponent<CapsuleCollider2D>();
        capsuleCollider2D.direction = CapsuleDirection2D.Horizontal;
        capsuleCollider2D.size = boatSize;
        capsuleCollider2D.sharedMaterial = bouncyMaterial;
        currentSlime.gameObject.layer = floorLayer;

        currentSlime.GetComponent<Rigidbody2D>().mass = 30f;

        currentSlime.gameObject.AddComponent<Boat>();
    }

    private void UseWall()
    {
        currentSlime.Crafted(AbilityType.Wall);

        Craft(currentSlime.gameObject);

        currentSlime.GetComponent<CapsuleCollider2D>().enabled = false;
        currentSlime.GetComponent<BoxCollider2D>().enabled = true;

        currentSlime.GetComponent<Rigidbody2D>().mass = 10f * 1000f;

        currentSlime.gameObject.AddComponent<Block>();
    }

    private void UseHorn(List<Slime> ableSlimes)
    {
        ableSlimes.ForEach(slime => slime.Pause());

        AudioManager.GetInstance().PlayStatus(Slime.SlimeStatus.Paused);

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
