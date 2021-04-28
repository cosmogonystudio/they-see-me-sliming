using UnityEngine;

public class AbilityUseOnClick : MonoBehaviour
{

    [SerializeField]
    private LayerMask layerMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, Mathf.Infinity, layerMask);

            if (hit.collider != null)
            {
                GameManager.GetInstance().UseAbility(hit.collider.gameObject.GetComponent<Slime>());
            }
        }
    }

}
