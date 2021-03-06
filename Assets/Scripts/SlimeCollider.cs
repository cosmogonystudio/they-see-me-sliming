using UnityEngine;

public abstract class SlimeCollider : MonoBehaviour
{

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Slime.slimeTag))
        {
            OnSlime(collision.gameObject.GetComponent<Slime>());
        }
    }

    protected abstract void OnSlime(Slime slime);

}
