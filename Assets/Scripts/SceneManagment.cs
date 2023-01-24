using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public void Restart()
    {//Game scene
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
    public void MainMenu()
    {//Menu scene
        SceneManager.LoadScene("MainMenu");
    }

}
