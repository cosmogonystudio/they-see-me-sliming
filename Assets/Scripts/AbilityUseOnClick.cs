using UnityEngine;

public class AbilityUseOnClick : MonoBehaviour
{

    [SerializeField]
    private LayerMask slimeLayerMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.GetInstance().GetLevelOverSlimeStatus() == Slime.SlimeStatus.Default)
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, Mathf.Infinity, slimeLayerMask);

            if (hit.collider != null)
            {
                GameManager.GetInstance().UseAbility(hit.collider.gameObject.GetComponent<Slime>());
            }
        }
    }

}
