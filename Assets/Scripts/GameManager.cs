using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private PlayerController playerControllerScript;

    private void Awake()
    {
        instance = this;
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
}
