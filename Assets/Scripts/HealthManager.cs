using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth;
    public int maxHealth= 3;

    public float invincibleLength = 0.5f;
    private float invincibleCounter;

    public Sprite[] healthBarImages;

    public Volume volume;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            //If the instance already exists, we destroy it
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //The health gets full at the start of the game
        ResetHealth();
        if (volume.profile.TryGet<Vignette>(out var vignette))
        {
            vignette.active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //The invincible counter gives us some time after getting hit
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            for (int i = 0; i < PlayerController.instance.playerParts.Length; i++)
            {
                //The player's body appears and disappears so we can visually see this invinciblity
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
                //The character dies and we xhange to the "gameover" scene
                currentHealth = 0;
                PlayerController.instance.PlayerDeath();
                GameManager.instance.GameOver();
            }
            else
            {
                //The player has recoil if it gets hit
                PlayerController.instance.Knockback();
                invincibleCounter = invincibleLength;
                //The health bar gets updated
                UpdateUI();
            }
        }
        
    }
    public void ResetHealth()
    {
        //The player's health gets full
        currentHealth = maxHealth;
        UIManager.instance.healthImage.enabled = true;
        UpdateUI();
    }
    public void AddHealth(int amountToHeal)
    {
        //When we pick the heart item, the health gets restored
        currentHealth += amountToHeal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (volume.profile.TryGet<Vignette>(out var vignette))
        {
            vignette.active = false;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        UIManager.instance.healthText.text = currentHealth.ToString();

        //The health image on the UI gets updateds
        switch (currentHealth)
        {
            case 5:
                UIManager.instance.healthImage.sprite = healthBarImages[4];
                break;
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
                //When we have low life, we show a red vignette effects
                if (volume.profile.TryGet<Vignette>(out var vignette))
                {
                    vignette.active = true;
                }
                break;
            case 0:
                UIManager.instance.healthImage.enabled = false;
                break;
        }
    }

}
