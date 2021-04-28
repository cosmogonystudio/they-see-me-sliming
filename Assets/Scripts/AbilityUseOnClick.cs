using UnityEngine;

[RequireComponent(typeof(AbilitySwap))]
public class AbilityUseOnClick : MonoBehaviour
{

    [SerializeField]
    private LayerMask slimeLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, Mathf.Infinity, slimeLayer);

            if (hit.collider != null)
            {
                GameManager.GetInstance().UseAbility(hit.collider.gameObject.GetComponent<Slime>());
            }
        }
    }

}
