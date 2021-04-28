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

    public const string floorTag = "Floor";

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float maxFallTime;

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

    private float currentFallTime = 0f;

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

        if (isActiveAndEnabled == true)
        {
            StartCoroutine(OnWalk());
        }
    }

    public void Fall()
    {
        animator.speed = 0f;
        animator.enabled = false;

        spriteRenderer.sprite = spriteFall;

        slimeStatus = SlimeStatus.InAir;
    }

    public void Pause()
    {
        if (isActiveAndEnabled == true)
        {
            StartCoroutine(OnPause());
        }
    }

    public void Crafted(AbilitySwap.AbilityType abilityType, bool sleepRigidbody = true)
    {
        if (sleepRigidbody)
        {
            m_rigidbody2D.Sleep();
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
        currentFallTime = 0f;

        m_rigidbody2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Fall();
    }

    void FixedUpdate()
    {
        if (slimeStatus == SlimeStatus.InAir)
        {
            currentFallTime += Time.fixedDeltaTime;
        }
        else if (slimeStatus == SlimeStatus.Default)
        {
            m_rigidbody2D.MovePosition(m_rigidbody2D.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(floorTag) && slimeStatus == SlimeStatus.InAir)
        {
            if (currentFallTime >= maxFallTime)
            {
                Die();
            }
            else
            {
                currentFallTime = 0f;

                KeepWalking();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(floorTag) && slimeStatus == SlimeStatus.Default)
        {
            Fall();
        }
    }

    IEnumerator OnWalk()
    {
        yield return new WaitForSeconds(0.25f);

        slimeStatus = SlimeStatus.Default;
    }

    IEnumerator OnPause()
    {
        yield return new WaitForFixedUpdate();

        m_rigidbody2D.Sleep();

        slimeStatus = SlimeStatus.Paused;

        spriteRenderer.sprite = spriteScared;

        animator.speed = 1f;
        animator.SetTrigger(SlimeAnimationBehaviour.animationScared);
    }

    private void SlimeIt()
    {
        GameManager.GetInstance().SlimeIt(slimeStatus);
    }

}
