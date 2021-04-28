using UnityEngine;

public class Slime : MonoBehaviour
{

    public enum SlimeStatus
    {
        Default,
        InAir,
        Paused,
        Used,
        Dead,
        Deeper
    }

    [SerializeField]
    private float moveSpeed;
    
    [SerializeField]
    private Sprite spriteDefault;
    [SerializeField]
    private Sprite spriteFall;
    [SerializeField]
    private Sprite spriteBridge;
    [SerializeField]
    private Sprite spriteHook;
    [SerializeField]
    private Sprite spriteCannon;
    [SerializeField]
    private Sprite spriteBoat;
    [SerializeField]
    private Sprite spriteWall;
    [SerializeField]
    private Sprite spriteScared;

    private Rigidbody2D m_rigidbody2D;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private Vector2 direction = Vector2.right;

    private SlimeStatus slimeStatus;

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public Vector2 GetDirection()
    {
        return direction;
    }

    public SlimeStatus GetSlimeStatus()
    {
        return slimeStatus;
    }

    public void KeepWalking()
    {
        m_rigidbody2D.WakeUp();

        spriteRenderer.sprite = spriteDefault;

        animator.enabled = true;
        animator.speed = 1f;
        animator.SetTrigger(SlimeAnimationBehaviour.animationWalking);

        slimeStatus = SlimeStatus.Default;
    }

    public void Fall()
    {
        m_rigidbody2D.WakeUp();

        spriteRenderer.sprite = spriteFall;

        animator.speed = 0f;
        animator.enabled = false;

        slimeStatus = SlimeStatus.InAir;
    }

    public void Pause()
    {
        m_rigidbody2D.Sleep();

        slimeStatus = SlimeStatus.Paused;

        spriteRenderer.sprite = spriteScared;

        animator.speed = 1f;
        animator.SetTrigger(SlimeAnimationBehaviour.animationScared);
    }

    public void Crafted(AbilitySwap.AbilityType abilityType)
    {
        switch (abilityType)
        {
            case AbilitySwap.AbilityType.Bridge:
                spriteRenderer.sprite = spriteBridge;
                break;
            case AbilitySwap.AbilityType.Hook:
                spriteRenderer.sprite = spriteHook;
                break;
            case AbilitySwap.AbilityType.Cannon:
                spriteRenderer.sprite = spriteCannon;
                break;
            case AbilitySwap.AbilityType.Boat:
                spriteRenderer.sprite = spriteBoat;
                break;
            case AbilitySwap.AbilityType.Wall:
                spriteRenderer.sprite = spriteWall;
                break;
            default:
                break;
        }
    }

    public void Use(AbilitySwap.AbilityType abilityType)
    {
        slimeStatus = SlimeStatus.Used;

        if (abilityType == AbilitySwap.AbilityType.Horn)
        {
            animator.SetTrigger(SlimeAnimationBehaviour.animationHorn);
        }
        else
        {
            animator.SetTrigger(SlimeAnimationBehaviour.animationCraft);

            SlimeIt();
        }
    }

    public void Die()
    {
        slimeStatus = SlimeStatus.Dead;

        animator.enabled = true;
        animator.speed = 1f;
        animator.SetTrigger(SlimeAnimationBehaviour.animationDie);

        SlimeIt();
    }

    public void DeeperAndDeeper()
    {
        slimeStatus = SlimeStatus.Deeper;

        SlimeIt();

        gameObject.SetActive(false);
    }

    public void Invert()
    {
        direction *= -1;

        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        animator.speed = 0f;
    }

    private void SlimeIt()
    {
        GameManager.GetInstance().SlimeIt(slimeStatus);
    }

}
