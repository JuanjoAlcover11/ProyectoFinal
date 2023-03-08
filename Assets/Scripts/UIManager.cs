using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image blackImage;
    public float fadeSpeed;
    public bool fadeToBlack;

    public TextMeshProUGUI healthText;
    public Image healthImage;

    public TextMeshProUGUI pointsText;

    public GameObject optionsPanel;
    public GameObject controlsPanel;

    public Slider musicSlider, sfxSlider;

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

    private void Start()
    {
        //We update the UI score 
        pointsText.text = DataPersistance.PlayerStats.currentScore.ToString();
    }

    public void OpenOptions()
    {
        //We open the options panel
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        //We close the options panel
        optionsPanel.SetActive(false);
    }

    public void OpenControls()
    {
        //We open the controls panel
        controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        //We close the controls panel
        controlsPanel.SetActive(false);
    }

    public void SetMusicLevel()
    {
        //The music volume changes with the music slider
        AudioManager.instance.SetMusicLevel();
    }
    public void SetSFXLevel()
    {
        //The SFX volume changes with the music slider
        AudioManager.instance.SetSFXLevel();
    }

    void Update()
    {
        if (fadeToBlack)
        {
            //The fade to black that appears when we die
            blackImage.color = new Color(blackImage.color.r, blackImage.color.g, blackImage.color.b, Mathf.MoveTowards(blackImage.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (blackImage.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }
    }
}
