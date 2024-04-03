using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonBehavior : MonoBehaviour
{
    public TMP_InputField answer;
    public string equationAnswer;
    public bool isButtonActivated = false;
    public int isAnswerChecked = 0;

    public void GetAnswer()
    {
        equationAnswer =  answer.text.ToString();
        isButtonActivated = true;
        if (isAnswerChecked == 0)
        {
            isAnswerChecked = -1;
        }
        //0 - ответ еще не задан
        //-1 - ответ задан, но не проверен
        //1 - ответ задан и проверен
    }
}
