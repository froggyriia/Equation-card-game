using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MonsterBehavior : MonoBehaviour
{
    public int monsterHealth;
    public int monsterMaxHealth;
    public Slider slider;
    public AudioSource damageSound;
    [SerializeField] Sprite damagedSprite;
    [SerializeField] Sprite origSprite;

    void Start()
    {
        SetMaxHealth(monsterMaxHealth);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void MonsterDamadged()
    {
        Debug.Log("Monster Damadged");
        damageSound.Play();
        ChangetoDamagedSprite();
        if (monsterHealth - 15 <= 0)
        {
            monsterHealth = 0;
            SetHealth(monsterHealth);
            MonsterDefeated();

        }
        monsterHealth -= 15;
        
        SetHealth(monsterHealth);
        Invoke("ChangetoOrigSprite", 1);

    }


    public void MonsterDefeated()
    {
        Debug.Log("Monster Defeated");
        GoToWinScreen();
    }

    public void GoToWinScreen()
    {
        SceneManager.LoadScene("Win Scene");
    }

    public void ChangetoDamagedSprite()
    {
        GetComponent<SpriteRenderer>().sprite = damagedSprite;
    }

    public void ChangetoOrigSprite()
    {
        GetComponent<SpriteRenderer>().sprite = origSprite;
    }
}

