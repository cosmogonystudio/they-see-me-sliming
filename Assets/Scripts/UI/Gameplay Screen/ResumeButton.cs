using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeButton : Button
{
    [SerializeField] GameObject pausePanel;

    public override void OnPointerClick(PointerEventData eventData)
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

}
