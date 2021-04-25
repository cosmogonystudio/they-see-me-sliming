using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CreditsButton : Button
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Botão para abrir a tela de créditos");
    }
}
