using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsButton : MenuButton
{

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Esse botão abre a tela de opções");
    }

}
