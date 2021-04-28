using UnityEngine;
using UnityEngine.EventSystems;

public class ScoreButton : MenuButton
{

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Este botão te levará para a tela de score");
    }

}
