using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class CardsBehavior : MonoBehaviour
{
    public Image oldImage;
    public Sprite newImage;
    public Sprite originalImage;
    public Timer timer;
    public ButtonBehavior buttonBehavior;
    private CanvasBehavior canvasBehavior;
    private MonsterBehavior monster;
    private PlayerBehavior player;


    public bool easyCardActivated = false;
    public bool mediumCardActivated = false;
    public bool hardCardActivated = false;
    string correctAnswer;

    [SerializeField] TextMeshProUGUI equationText;



    void Start()
    {

 
        timer = GameObject.Find("Canvas").GetComponent<Timer>();
        buttonBehavior = GameObject.Find("Button").GetComponent<ButtonBehavior>();
        canvasBehavior = GameObject.Find("Canvas").GetComponent<CanvasBehavior>();
        monster = GameObject.Find("Monster").GetComponent<MonsterBehavior>();
        player = GameObject.Find("Player").GetComponent<PlayerBehavior>();

    }

    void Update()
    {
        if (timer.remainingTime <= 0)
        {
            CheckAnswer();
           
        }

        if (buttonBehavior.isAnswerChecked == -1)
        {
            CheckAnswer();
        }

        
    }

    public void ImageChange()
    {

        if (canvasBehavior.activatedCardsCount == 0 && timer.remainingTime > 0)
        {
            buttonBehavior.isAnswerChecked = 0;
            oldImage.sprite = newImage;
            canvasBehavior.activatedCardsCount++;
            timer.isTimerActivated = true;

            if (this.tag == "easy")
            {

                string easyKey = GetRandomKey(canvasBehavior.easyEquationsDict);
                correctAnswer = canvasBehavior.easyEquationsDict[easyKey].ToString();
                Debug.Log(correctAnswer);
                equationText.text = easyKey;


            }
            if (this.tag == "medium")
            {
                string mediumKey = GetRandomKey(canvasBehavior.mediumEquationsDict);
                correctAnswer = canvasBehavior.mediumEquationsDict[mediumKey].ToString();
                Debug.Log("correct ans: " + correctAnswer);

                equationText.text = mediumKey;
            }
            if (this.tag == "hard")
            {
                string hardKey = GetRandomKey(canvasBehavior.hardEquationsDict);
                correctAnswer = canvasBehavior.hardEquationsDict[hardKey].ToString();
                Debug.Log("correct ans: " + correctAnswer);
                equationText.text = hardKey;
            }


        }


    }

    public void ImageChangeBack()
    {
        equationText.text = "";
        canvasBehavior.activatedCardsCount--;
        Debug.Log(canvasBehavior.activatedCardsCount);
        oldImage.sprite = originalImage;
        timer.isTimerActivated = false;
        timer.remainingTime = timer.originalTime;
        
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


    
}
    
