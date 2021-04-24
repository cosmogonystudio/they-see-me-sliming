using UnityEngine;

public class Slime : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D m_rigidbody2D;

    private bool inAir = false;

    private const string floorTag = "Floor";

    void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (inAir == false)
        {
            m_rigidbody2D.MovePosition(m_rigidbody2D.position + Vector2.right * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(floorTag))
        {
            // Debug.Log("Slime:OnCollisionEnter2D:collision.collider.tag: " + collision.collider.tag);

            inAir = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(floorTag))
        {
            // Debug.Log("Slime:OnCollisionExit2D:collision.collider.tag: " + collision.collider.tag);

            inAir = true;
        }
    }

}
