using UnityEngine;

public abstract class SlimeCollider : MonoBehaviour
{

    private const string slimeTag = "Slime";

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(slimeTag))
        {
            OnSlime(collision.gameObject.GetComponent<Slime>());
        }
    }

    protected abstract void OnSlime(Slime slime);

}
