using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class RuleButton : MonoBehaviour
{
    [SerializeField] GameObject mainText;
    [SerializeField] GameObject rules;
    [SerializeField] GameObject closeButton;
    public void ShowTheRules()
    {
        mainText.SetActive(false);
        rules.SetActive(true);
        closeButton.SetActive(true);
    }

    public void CloseTheRules()
    {
        mainText.SetActive(true);
        rules.SetActive(false);
        closeButton.SetActive(false);
    }
}
