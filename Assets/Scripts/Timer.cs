using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] public float remainingTime;
    public float originalTime;
    public bool isTimerActivated = false;
    void Start()
    {
        originalTime = remainingTime;
    }

    void Update()
    {
        if (remainingTime > 0 && isTimerActivated)
        {
            remainingTime -= Time.deltaTime;
            
        }

        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
