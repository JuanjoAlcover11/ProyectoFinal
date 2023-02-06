using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private PlayerController playerControllerScript;

    public int currentPoints;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerControllerScript = FindObjectOfType<PlayerController>();
    }


    void Update()
    {
        
    }

    public void GameOver()
    {
        StartCoroutine(GameOverWait());
    }

    public IEnumerator GameOverWait()
    {
        UIManager.instance.fadeToBlack = true;
        playerControllerScript.animator.SetBool("isDead", true);
        yield return new WaitForSeconds(2f);
        Debug.Log("You died");
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("GameOver");
    }

    public void addPoints(int pointsToAd)
    {
        currentPoints += pointsToAd;
        UIManager.instance.pointsText.text = currentPoints.ToString();
    }
}
