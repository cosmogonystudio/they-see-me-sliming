using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MenuButton
{

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Esse botão vai iniciar o jogo");

        SceneManager.LoadScene(1);
    }

}
