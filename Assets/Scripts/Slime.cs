using System.Collections;
using System.Collections.Generic;
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

    private Rigidbody2D m_rigidbody2D;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private Vector2 direction = Vector2.right;

    private SlimeStatus slimeStatus;

    private const string floorTag = "Floor";

    public SlimeStatus GetSlimeStatus()
    {
        return slimeStatus;
    }

    public void KeepWalking()
    {
        spriteRenderer.sprite = spriteDefault;

        slimeStatus = SlimeStatus.Default;

        animator.speed = 1f;

        animator.SetTrigger(SlimeAnimationBehaviour.animationWalking);
    }

    public void Fall()
    {
        animator.speed = 0f;

        spriteRenderer.sprite = spriteFall;

        slimeStatus = SlimeStatus.InAir;
    }

    public void Pause()
    {
        slimeStatus = SlimeStatus.Paused;

        animator.SetTrigger(SlimeAnimationBehaviour.animationScared);
    }

    public void Crafted(AbilitySwap.AbilityType abilityType, bool sleepRigidbody = true)
    {
        if (sleepRigidbody)
        {
            m_rigidbody2D.Sleep();
        }
        else
        {
            m_rigidbody2D.bodyType = RigidbodyType2D.Static;
        }

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
        } else
        {
            animator.SetTrigger(SlimeAnimationBehaviour.animationCraft);
        }

        SlimeIt();
    }

    public void Die(bool slimeIt = true)
    {
        slimeStatus = SlimeStatus.Dead;

        animator.SetTrigger(SlimeAnimationBehaviour.animationDie);

        if (slimeIt)
        {
            SlimeIt();
        }
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

    void FixedUpdate()
    {
        if (slimeStatus == SlimeStatus.Default)
        {
            m_rigidbody2D.MovePosition(m_rigidbody2D.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(floorTag) && slimeStatus != SlimeStatus.Used)
        {
            KeepWalking();
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(floorTag) && slimeStatus != SlimeStatus.Used)
        {
            Fall();
        }
    }

    private void SlimeIt()
    {
        GameManager.GetInstance().SlimeIt(slimeStatus);
    }

}
