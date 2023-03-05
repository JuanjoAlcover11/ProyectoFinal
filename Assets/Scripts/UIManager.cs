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

    public Slider musicSlider, sfxSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void SetMusicLevel()
    {
        AudioManager.instance.SetMusicLevel();
    }
    public void SetSFXLevel()
    {
        AudioManager.instance.SetSFXLevel();
    }

    void Update()
    {
        if (fadeToBlack)
        {
            blackImage.color = new Color(blackImage.color.r, blackImage.color.g, blackImage.color.b, Mathf.MoveTowards(blackImage.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (blackImage.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }
    }
}
