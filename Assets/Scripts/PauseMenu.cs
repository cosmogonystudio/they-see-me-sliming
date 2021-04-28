using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject pausePanel;

    private bool speedUp = false;

    void Awake()
    {
        speedUp = false;
    }

    void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Time.timeScale > 0f)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
            else
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SpeedUpGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;

        pausePanel.SetActive(true);
    }

    private void SpeedUpGame()
    {
        speedUp = !speedUp;

        Time.timeScale = speedUp ? 10f : 1f;
    }

}
