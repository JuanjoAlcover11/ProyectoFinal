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
            Destroy(gameObject);
        }
    }
    public void Restart()
    {//Game scene
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void StartGame()
    {//Game scene
        StartCoroutine(StartWait());
    }

    public void MainMenu()
    {//Menu scene
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator StartWait()
    {
        animator.SetBool("isStart", true);
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

}
