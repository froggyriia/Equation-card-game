using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasBehavior : MonoBehaviour
{
    public Timer timer;
    public List<CardsBehavior> cards = new List<CardsBehavior>(); 
    public bool timerIsRunning;
    public int activatedCardsCount = 0;

    

    public Dictionary<string, int> easyEquationsDict = new Dictionary<string, int>()
        {
            {"2x + 5 = 19", 7},
            {"3x - 2 = 10", 4}     
        };

    public Dictionary<string, int> mediumEquationsDict = new Dictionary<string, int>()
        {
            {"2x + 5 = 19", 7},
            {"3(x - 2) = 6", 4},
            {"x² + 4x + 3 = 0", -1},
            {"x² - 7x + 6 = 0", 6},
            {"(2x + 9)² = (2x - 1)²", -2},
            {"(x - 6)² = -24x", -6},
            {"x² -17x + 72 = 0", 9},
            {"x² + 9 = (x + 9)²", -4},
            {"√(2x) - 4 = 4", 32},
            {"√(15 - 2x) = 3", 3},
            {"√(3x - 8) = 5", 11},
            {"√(x - 2) = 6", 38},
            {"√(-32 - x) = 2", -36},
            
        };

    public Dictionary<string, int> hardEquationsDict = new Dictionary<string, int>()
        {
            {"log(x, 5) + √(2x) = 0", -1}
            
        };



    void Start()
    {
        timer = FindObjectOfType<Timer>();
        cards.AddRange(FindObjectsOfType<CardsBehavior>()); 
    }

    void Update()
    {
        if (timer != null && timer.remainingTime <= 0)
        {
            timerIsRunning = false;
        }

        else if (timer.remainingTime > 0)
        {
            timerIsRunning = true;
        }
    }

    

}