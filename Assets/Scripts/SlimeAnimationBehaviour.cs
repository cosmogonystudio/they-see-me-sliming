using UnityEngine;

public class SlimeAnimationBehaviour : StateMachineBehaviour
{

    public const string animationWalking = "Walking";
    public const string animationCraft = "Craft";
    public const string animationHorn = "Horn";
    public const string animationScared = "Scared";
    public const string animationDie = "Die";
    
    private int stateHashCraft;
    private int stateHashHorn;
    private int stateHashScared;
    private int stateHashDie;

    void Awake()
    {
        stateHashCraft = Animator.StringToHash(animationCraft);
        stateHashHorn = Animator.StringToHash(animationHorn);
        stateHashScared = Animator.StringToHash(animationScared);
        stateHashDie = Animator.StringToHash(animationDie);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int currentShortNameHash = animator.GetCurrentAnimatorStateInfo(layerIndex).shortNameHash;
        
        if (currentShortNameHash == stateHashCraft)
        {
            animator.enabled = false;

            GameManager.GetInstance().OnAbilityUse();
        }
        else if (currentShortNameHash == stateHashHorn || currentShortNameHash == stateHashScared)
        {
            animator.speed = 0f;

            GameManager.GetInstance().OnAbilityUse();
        }
        else if (currentShortNameHash == stateHashDie)
        {
            animator.gameObject.SetActive(false);
        }
    }

}
