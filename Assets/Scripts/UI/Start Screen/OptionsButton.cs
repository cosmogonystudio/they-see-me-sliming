using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class OptionsButton : Button
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Esse botão abre a tela de opções");
    }
}
