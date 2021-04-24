using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuitButton : Button
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Botão para sair do jogo");
    }

}
