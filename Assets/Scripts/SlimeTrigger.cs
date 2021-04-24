using UnityEngine;

public abstract class SlimeTrigger : MonoBehaviour
{

    private const string slimeTag = "Slime";

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(slimeTag))
        {
            // Debug.Log("SlimeTrigger:OnTriggerEnter2D:collision.name: " + collision.name);

            collision.gameObject.SetActive(false);

            if (GameManager.GetInstance().SlimeUp())
            {
                OnAllSmiles();
            }
        }
    }

    protected abstract void OnAllSmiles();

}
