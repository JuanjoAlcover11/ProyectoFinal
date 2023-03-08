using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public CharacterController charController;
    public Animator animator;

    public static SceneManagment instance;
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
    public void Restart()
    {
        //The game starts from the beginning
        Time.timeScale = 1f;
        DataPersistance.PlayerStats.currentScore = 0;
        SceneManager.LoadScene("MainScene");
    }

    public void StartGame()
    {
        //We start the game with some delay for the menu animation
        StartCoroutine(StartWait());
        DataPersistance.PlayerStats.currentScore = 0;
    }

    public void MainMenu()
    {
        //We go to the main menu scene
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator StartWait()
    {
        //We set the delay for the StartGame and the player animation
        animator.SetBool("isStart", true);
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

}
