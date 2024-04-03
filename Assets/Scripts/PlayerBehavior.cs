using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public int playerHealth;
    public int playerMaxHealth;
    public Slider slider;
    public int playerDamage;
    public AudioSource damageSound;
    [SerializeField] Sprite damagedSprite;
    [SerializeField] Sprite origSprite;

    void Start()
    {
        
        SetMaxHealth(playerMaxHealth);
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

    public void PlayerDamadged()
    {
        Debug.Log("Player Damadged");
        damageSound.Play();
        ChangetoDamagedSprite();
        if ((playerHealth - 5) <= 0)
        {
            playerHealth = 0;
            SetHealth(playerHealth);
            PlayerDefeated();
        }
        playerHealth -= 5;
        SetHealth(playerHealth);

        Invoke("ChangetoOrigSprite", 1);
    }

    public void PlayerDefeated()
    {
        Debug.Log("player defeated");
        GoToLoseScreen();
    }

    public void GoToLoseScreen()
    {
        SceneManager.LoadScene("Lose Scene");
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
