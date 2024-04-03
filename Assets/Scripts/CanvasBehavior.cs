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

    public Image easyImage;
    [SerializeField] TextMeshProUGUI easyEquationText;
    public Image mediumImage;
    [SerializeField] TextMeshProUGUI mediumEquationText;
    public Image hardImage;
    [SerializeField] TextMeshProUGUI hardEquationText;
    public Sprite newImage;
    public Sprite originalImage;
    
    public ButtonBehavior buttonBehavior;
    private CanvasBehavior canvasBehavior;
    private MonsterBehavior monster;
    private PlayerBehavior player;

    public CardsBehavior cardsBehavior;

    
    string correctAnswer;

    public string activatedCardTag;
    public bool cardWasActivated;
    

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
        buttonBehavior = GameObject.Find("Button").GetComponent<ButtonBehavior>();
        canvasBehavior = GameObject.Find("Canvas").GetComponent<CanvasBehavior>();
        monster = GameObject.Find("Monster").GetComponent<MonsterBehavior>();
        player = GameObject.Find("Player").GetComponent<PlayerBehavior>();
        

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

        if (timer.remainingTime <= 0)
        {
            CheckAnswer();

        }

        if (buttonBehavior.isAnswerChecked == -1)
        {
            CheckAnswer();
        }
        if (cardWasActivated)
        {
            ImageChange();
            cardWasActivated = false;
        }
    }

    public void ImageChange()
    {

        if (canvasBehavior.activatedCardsCount == 1 && timer.remainingTime > 0)
        {
            buttonBehavior.isAnswerChecked = 0;
            
            
            timer.isTimerActivated = true;

            if (activatedCardTag == "easy")
            {
                easyImage.sprite = newImage;
                string easyKey = GetRandomKey(canvasBehavior.easyEquationsDict);
                correctAnswer = canvasBehavior.easyEquationsDict[easyKey].ToString();
                Debug.Log(correctAnswer);
                easyEquationText.text = easyKey;


            }
            if (activatedCardTag == "medium")
            {
                mediumImage.sprite = newImage;
                string mediumKey = GetRandomKey(canvasBehavior.mediumEquationsDict);
                correctAnswer = canvasBehavior.mediumEquationsDict[mediumKey].ToString();
                Debug.Log("correct ans: " + correctAnswer);

                mediumEquationText.text = mediumKey;
            }
            if (activatedCardTag == "hard")
            {
                hardImage.sprite = newImage;
                string hardKey = GetRandomKey(canvasBehavior.hardEquationsDict);
                correctAnswer = canvasBehavior.hardEquationsDict[hardKey].ToString();
                Debug.Log("correct ans: " + correctAnswer);
                hardEquationText.text = hardKey;
            }
            

        }


    }

    public static string GetRandomKey(Dictionary<string, int> dictionary)
    {
        List<string> keys = new List<string>(dictionary.Keys);
        System.Random rand = new System.Random();
        int randomIndex = rand.Next(0, keys.Count);
        return keys[randomIndex];
    }
    public void CheckAnswer()
    {
        Debug.Log("correct ans: " + correctAnswer);
        Debug.Log("answer from butt: " + buttonBehavior.equationAnswer);
        Debug.Log(correctAnswer == buttonBehavior.equationAnswer);
        buttonBehavior.isAnswerChecked = 1;
        if (timer.remainingTime <= 0)
        {
            Debug.Log("just too late");
            player.PlayerDamadged();
        }
        else if (correctAnswer == buttonBehavior.equationAnswer)
        {
            Debug.Log("coorect");

            monster.MonsterDamadged();

        }
        else
        {
            Debug.Log("lox");
            player.PlayerDamadged();

        }
        buttonBehavior.isButtonActivated = false;
        ImageChangeBack();

    }

    public void ImageChangeBack()
    {
        easyEquationText.text = "";
        mediumEquationText.text = "";
        hardEquationText.text = "";
        canvasBehavior.activatedCardsCount--;
        Debug.Log(canvasBehavior.activatedCardsCount);
        easyImage.sprite = originalImage;
        mediumImage.sprite = originalImage;
        hardImage.sprite = originalImage;
        timer.isTimerActivated = false;
        timer.remainingTime = timer.originalTime;

    }
}