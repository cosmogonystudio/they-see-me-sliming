using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeButton : MenuButton
{

    [SerializeField]
    GameObject pausePanel;

    public override void OnPointerClick(PointerEventData eventData)
    {
        pausePanel.SetActive(false);

        Time.timeScale = 1f;
    }

}
