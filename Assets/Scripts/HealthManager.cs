using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth;
    public int maxHealth= 3;

    public float invincibleLength = 1f;
    private float invincibleCounter;
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            for (int i = 0; i < PlayerController.instance.playerParts.Length; i++)
            {
                if (Mathf.Floor(invincibleCounter * 5f) % 2 == 0)
                {
                    PlayerController.instance.playerParts[i].SetActive(true);
                }
                else
                {
                    PlayerController.instance.playerParts[i].SetActive(false);
                }

                if (invincibleCounter <= 0)
                {
                    PlayerController.instance.playerParts[i].SetActive(true);
                }
            }
        }
    }

    public void Damage()
    {
        if (invincibleCounter <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                GameManager.instance.GameOver();
            }
            else
            {
                PlayerController.instance.Knockback();
                invincibleCounter = invincibleLength;
            }
        }
        
    }
    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
    public void AddHealth(int amountToHeal)
    {
        currentHealth = +amountToHeal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
