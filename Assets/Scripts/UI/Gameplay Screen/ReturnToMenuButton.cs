using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnToMenuButton : MenuButton
{

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Voltar para o menu inicial"); // TODO!
    }

}
