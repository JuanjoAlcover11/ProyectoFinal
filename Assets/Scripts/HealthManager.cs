using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth;
    public int maxHealth= 3;

    public float invincibleLength = 1f;
    private float invincibleCounter;

    public Sprite[] healthBarImages;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ResetHealth();
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
        UIManager.instance.healthImage.enabled = true;
        UpdateUI();
    }
    public void AddHealth(int amountToHeal)
    {
        currentHealth = +amountToHeal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        UIManager.instance.healthText.text = currentHealth.ToString();

        switch (currentHealth)
        {
            case 4:
                UIManager.instance.healthImage.sprite = healthBarImages[3];
                break;
            case 3:
                UIManager.instance.healthImage.sprite = healthBarImages[2];
                break;
            case 2:
                UIManager.instance.healthImage.sprite = healthBarImages[1];
                break;
            case 1:
                UIManager.instance.healthImage.sprite = healthBarImages[0];
                break;
            case 0:
                UIManager.instance.healthImage.enabled = false;
                break;
        }
    }

}
