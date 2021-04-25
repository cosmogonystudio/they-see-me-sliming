using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUseOnClick : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 mousePosition = Input.mousePosition;
        
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        if (hit2D.collider != null) {
                IAbility ability = hit2D.collider.GetComponent<IAbility>();
                ability.useAbility(mousePosition);
        }
    }
    }
}

