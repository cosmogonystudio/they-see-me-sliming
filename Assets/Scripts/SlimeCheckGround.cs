using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCheckGround : MonoBehaviour
{

    private Slime slime;
    private Rigidbody2D m_rigidbody2D;
    private Collider2D coll;
    [SerializeField] private float boxReach;
    [SerializeField] private LayerMask layer;

    private void Awake()
    {
        slime = GetComponent<Slime>();

        m_rigidbody2D = GetComponent<Rigidbody2D>();

        coll = GetComponent<CapsuleCollider2D>();
        
    }
    void FixedUpdate()
    {

        CheckGround();

        if (slime.GetSlimeStatus() == Slime.SlimeStatus.Default)
        {
            //m_rigidbody2D.velocity = Vector2.zero;
            //Debug.Log("called");
            m_rigidbody2D.MovePosition(m_rigidbody2D.position + slime.direction * slime.moveSpeed * Time.fixedDeltaTime);
        }

        //Debug.Log(m_rigidbody2D.velocity);
    }

    void CheckGround()
    {
        RaycastHit2D hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, boxReach, layer);
        if(hit.collider != null)
        {
            slime.KeepWalking();
        } else 
        {
            slime.Fall();
        }

        //Debug.Log(slime.GetSlimeStatus());
    }

}
