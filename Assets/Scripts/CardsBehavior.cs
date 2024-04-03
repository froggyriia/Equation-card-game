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

 
        //timer = GameObject.Find("Canvas").GetComponent<Timer>();
        //buttonBehavior = GameObject.Find("Button").GetComponent<ButtonBehavior>();
        canvasBehavior = GameObject.Find("Canvas").GetComponent<CanvasBehavior>();
        //monster = GameObject.Find("Monster").GetComponent<MonsterBehavior>();
        //player = GameObject.Find("Player").GetComponent<PlayerBehavior>();

    }

    void Update()
    {
        //if (timer.remainingTime <= 0)
        //{
        //    CheckAnswer();
           
        //}

        //if (buttonBehavior.isAnswerChecked == -1)
        //{
        //    CheckAnswer();
        //}

        
    }


    public void CardWasActivated()
    {
        if (canvasBehavior.activatedCardsCount == 0)
        {
            canvasBehavior.activatedCardsCount++;
            canvasBehavior.cardWasActivated = true;
            if(this.tag == "medium")
            {
                canvasBehavior.activatedCardTag = tag;

                Debug.Log(canvasBehavior.activatedCardTag);
            }

            if (this.tag == "easy")
            {
                canvasBehavior.activatedCardTag = tag;

                Debug.Log(canvasBehavior.activatedCardTag);
            }

            if (this.tag == "hard")
            {
                canvasBehavior.activatedCardTag = tag;
               
                Debug.Log(canvasBehavior.activatedCardTag);
            }
        }
    }
    


    
}
    
