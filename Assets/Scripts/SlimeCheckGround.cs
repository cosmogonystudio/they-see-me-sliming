using UnityEngine;

public class SlimeCheckGround : MonoBehaviour
{

    [SerializeField]
    private LayerMask groundLayerMask;

    [SerializeField]
    private float boxReach;
    [SerializeField]
    private float maxFallTime;

    private Slime slime;

    private Rigidbody2D m_rigidbody2D;

    private Collider2D coll;

    private float currentFallTime = 0f;

    void Awake()
    {
        currentFallTime = 0f;

        slime = GetComponent<Slime>();

        m_rigidbody2D = GetComponent<Rigidbody2D>();

        coll = GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate()
    {
        CheckGround();

        if (slime.GetSlimeStatus() == Slime.SlimeStatus.InAir)
        {
            currentFallTime += Time.fixedDeltaTime;
        }
        else
        if (slime.GetSlimeStatus() == Slime.SlimeStatus.Default)
        {
            m_rigidbody2D.MovePosition(m_rigidbody2D.position + slime.GetDirection() * slime.GetMoveSpeed() * Time.fixedDeltaTime);
        }
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, boxReach, groundLayerMask);

        if (hit.collider != null)
        {
            if (currentFallTime >= maxFallTime)
            {
                this.enabled = false;

                slime.Die();
            }
            else
            if (slime.GetSlimeStatus() != Slime.SlimeStatus.Default)
            {
                currentFallTime = 0f;

                slime.KeepWalking();
            }
        }
        else
        if (slime.GetSlimeStatus() == Slime.SlimeStatus.InAir)
        {
            if (currentFallTime > 0.1f)
            {
                slime.Fall();
            }
        }
        else
        {
            slime.Fall(false);
        }
    }

}
