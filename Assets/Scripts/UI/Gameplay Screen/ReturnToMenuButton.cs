using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnToMenuButton : Button
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Voltar para o menu inicial");
    }
}
