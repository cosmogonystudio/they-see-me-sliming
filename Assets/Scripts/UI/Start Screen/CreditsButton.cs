using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsButton : MenuButton
{

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Botão para abrir a tela de créditos");
    }

}
