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

    private Vector2 direction = Vector2.right;

    private SlimeStatus slimeStatus = SlimeStatus.Default;

    private const string floorTag = "Floor";

    public SlimeStatus GetSlimeStatus()
    {
        return slimeStatus;
    }

    public void KeepWalking()
    {
        slimeStatus = SlimeStatus.Default;
    }

    public void Fall()
    {
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

        gameObject.SetActive(false);

        SlimeIt();
    }

    public void Invert()
    {
        direction *= -1;
    }

    void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
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
        if (collision.gameObject.CompareTag(floorTag))
        {
            slimeStatus = SlimeStatus.Default;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(floorTag))
        {
            slimeStatus = SlimeStatus.InAir;
        }
    }

    private void SlimeIt()
    {
        GameManager.GetInstance().SlimeIt(slimeStatus);
    }

}
