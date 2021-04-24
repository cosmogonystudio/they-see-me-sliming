using UnityEngine;

public abstract class SlimeCollider : MonoBehaviour
{

    private const string slimeTag = "Slime";

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        SlimeCollide(collision.gameObject);
    }

    protected virtual void OnColliderEnter2D(Collider2D collision)
    {
        SlimeCollide(collision.gameObject);
    }

    protected abstract void OnSlime(Slime slime);

    private void SlimeCollide(GameObject collisionGameObject)
    {
        if (collisionGameObject.CompareTag(slimeTag))
        {
            OnSlime(collisionGameObject.GetComponent<Slime>());
        }
    }

}
