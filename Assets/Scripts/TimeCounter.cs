using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public float seconds;
    public int minutes;
    [SerializeField] TextMeshProUGUI timeText;


    private void Update()
    {
        if(seconds <= 60)
        {
            seconds += Time.deltaTime;
        } else
        {
            seconds = 0;
            minutes += 1;
        }
        
        timeText.text =  minutes.ToString() + ":" + ((int)seconds).ToString() + " " + "min";
    }
}
