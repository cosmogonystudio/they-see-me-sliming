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
    private WaitForSeconds pauseWaitForSeconds;
    public static AbilityType currentAbilityType = AbilityType.None;
    private Slime currentSlime;
    private List<Slime> currentAbleSlimes;
    private bool currentUsing = false;

    public void SetAbilityType(AbilityType abilityType)
    {
        currentAbilityType = abilityType;
    }

    public void UseAbility(Slime slime, List<Slime> ableSlimes)
    {
        if (currentUsing == true || currentAbilityType == AbilityType.None || ableSlimes.Contains(slime) == false)
        {
            return;
        }

        currentUsing = true;

        currentSlime = slime;
        currentAbleSlimes = ableSlimes;

        currentAbleSlimes.Remove(currentSlime);

        slime.Use(currentAbilityType);
    }

    public void OnAbilityUse()
    {
        if (currentUsing == false)
        {
            return;
        }

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
                UseHorn();
                break;
            default:
                break;
        }

        currentUsing = false;
    }

    void Awake()
    {
        pauseWaitForSeconds = new WaitForSeconds(pauseSeconds);
    }

    IEnumerator OnHorn(Slime slime, List<Slime> ableSlimes)
    {
        yield return pauseWaitForSeconds;

        slime.Die(false);

        ableSlimes.ForEach(slime => slime.KeepWalking());

        yield break;
    }

    private void UseBridge()
    {
        currentSlime.Crafted(AbilityType.Bridge);

        // TODO!
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

        // TODO!
    }

    private void UseWall()
    {
        currentSlime.Crafted(AbilityType.Wall, false);

        GameObject slimeGameObject = currentSlime.gameObject;

        slimeGameObject.tag = "Untagged";
        slimeGameObject.layer = defaultLayer;
        slimeGameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
        slimeGameObject.GetComponent<Slime>().enabled = false;
        slimeGameObject.GetComponent<SlimeCheckGround>().enabled = false;
        slimeGameObject.AddComponent<Block>();

        Debug.Log("wall call");
    }

    private void UseHorn()
    {
        currentAbleSlimes.ForEach(slime => slime.Pause());

        StartCoroutine(OnHorn(currentSlime, currentAbleSlimes));
    }

}
