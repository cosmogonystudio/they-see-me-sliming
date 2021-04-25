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

    private Rigidbody2D m_rigidbody2D;
    private Collider2D coll;
    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private Vector2 direction = Vector2.right;

    private SlimeStatus slimeStatus;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float boxReach;
    private const string floorTag = "Floor";

    public SlimeStatus GetSlimeStatus()
    {
        return slimeStatus;
    }

    public void KeepWalking()
    {
        animator.speed = 1f;

        slimeStatus = SlimeStatus.Default;
    }

    public void Fall()
    {
        animator.speed = 0f;

        slimeStatus = SlimeStatus.InAir;
    }

    public void Pause()
    {
        slimeStatus = SlimeStatus.Paused;
    }

    public void Use()
    {
        slimeStatus = SlimeStatus.Used;

        SlimeIt();
    }

    public void Die()
    {
        slimeStatus = SlimeStatus.Dead;

        gameObject.SetActive(false);

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

        coll = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        animator.speed = 0f;
        slimeStatus = SlimeStatus.InAir;
    }

    void FixedUpdate()
    {
        m_rigidbody2D.velocity = Vector2.zero;

        CheckGround();

        if (slimeStatus == SlimeStatus.Default)
        {
            m_rigidbody2D.MovePosition(m_rigidbody2D.position + direction * moveSpeed * Time.fixedDeltaTime);
        }

    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(floorTag))
        {
            KeepWalking();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(floorTag))
        {
            Fall();
        }
    }*/

    void CheckGround()
    {
        RaycastHit2D hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, boxReach, layer);
        if(hit.collider != null)
        {
            KeepWalking();
        } else 
        {
            Fall();
        }

        //Debug.Log(slimeStatus);
    }

    private void SlimeIt()
    {
        GameManager.GetInstance().SlimeIt(slimeStatus);
    }

}
