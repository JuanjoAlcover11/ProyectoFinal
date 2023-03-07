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

    public GameObject panelUI;

    private void Awake()
    {
        if(instance == null)
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
        //We hide and desactivate the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerControllerScript = FindObjectOfType<PlayerController>();
        //We show the game interface 
        panelUI.SetActive(true);
    }

    public void GameOver()
    {
        StartCoroutine(GameOverWait());
    }

    public IEnumerator GameOverWait()
    {
        UIManager.instance.fadeToBlack = true;
        //We hide the game interface 
        panelUI.SetActive(false);
        playerControllerScript.animator.SetBool("isDead", true);
        //We add a 2 seconds delay before we change the scene
        yield return new WaitForSeconds(2f);
        //We show and activate the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //We change the scene
        SceneManager.LoadScene("GameOver");
    }

    public void addPoints(int pointsToAd)
    {
        //We update our current points 
        currentPoints += pointsToAd;
        //On the UI too
        UIManager.instance.pointsText.text = currentPoints.ToString();
    }

    public void saveContador()
    {
        //We save your score, so we can also see it in the "You win" scene
        DataPersistance.PlayerStats.currentScore = currentPoints;
    }
}
