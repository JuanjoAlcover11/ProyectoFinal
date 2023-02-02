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


    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
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
