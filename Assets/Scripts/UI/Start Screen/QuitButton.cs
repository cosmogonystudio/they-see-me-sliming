using UnityEngine;
using UnityEngine.EventSystems;

public class QuitButton : MenuButton
{

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Botão para sair do jogo");
    }

}
