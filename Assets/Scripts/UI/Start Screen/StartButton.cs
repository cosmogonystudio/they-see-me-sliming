using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StartButton : Button
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Esse botão vai iniciar o jogo");

        SceneManager.LoadScene("MainScene");
    }
}
