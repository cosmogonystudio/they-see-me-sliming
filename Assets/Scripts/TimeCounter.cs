using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{

    static float seconds;

    static int minutes;

    [SerializeField]
    TextMeshProUGUI timeText;

    void Update()
    {
        if (seconds <= 60f)
        {
            seconds += Time.deltaTime;
        }
        else
        {
            seconds = 0f;

            minutes += 1;
        }
        
        timeText.text =  minutes + ":" + ((int)seconds) + " " + "min";
    }

}
