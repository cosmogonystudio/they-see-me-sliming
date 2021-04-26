using UnityEngine;

public abstract class SlimeTrigger : MonoBehaviour
{

    private const string slimeTag = "Slime";

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("alegoria");

        if (collision.gameObject.CompareTag(slimeTag))
        {
            //Debug.Log("margarida");

            OnSlime(collision.gameObject.GetComponent<Slime>());
        }
    }

    protected abstract void OnSlime(Slime slime);

}
