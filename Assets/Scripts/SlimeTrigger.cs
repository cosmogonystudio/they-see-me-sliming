using UnityEngine;

public abstract class SlimeTrigger : MonoBehaviour
{

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Slime.slimeTag))
        {
            OnSlime(collision.gameObject.GetComponent<Slime>());
        }
    }

    protected abstract void OnSlime(Slime slime);

}
