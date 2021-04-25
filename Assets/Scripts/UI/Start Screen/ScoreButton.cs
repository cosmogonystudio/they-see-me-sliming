using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScoreButton : Button
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Este botão te levará para a tela de score");
    }
}
