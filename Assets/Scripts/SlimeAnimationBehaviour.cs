using UnityEngine;

public class SlimeAnimationBehaviour : StateMachineBehaviour
{

    public const string animationWalking = "Walking";
    public const string animationCraft = "Craft";
    public const string animationHorn = "Horn";
    public const string animationScared = "Scared";
    public const string animationDie = "Die";
    public const string animationBullet = "Bullet";
    
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
        if (stateInfo.shortNameHash == stateHashCraft)
        {
            animator.speed = 0f;
            animator.enabled = false;

            GameManager.GetInstance().OnAbilityUse();
        }
        else
        if (stateInfo.shortNameHash == stateHashHorn)
        {
            animator.speed = 0f;
            animator.enabled = false;

            GameManager.GetInstance().OnAbilityUse();
        }
        else
        if (stateInfo.shortNameHash == stateHashScared)
        {
            animator.speed = 0f;
            animator.enabled = false;
        }
        else
        if (stateInfo.shortNameHash == stateHashDie)
        {
            GameManager.GetInstance().SlimeIt(Slime.SlimeStatus.Dead);
            animator.gameObject.SetActive(false);
        }
    }

}
