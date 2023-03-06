using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    private GameManager GameManagerScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManagerScript.saveContador();
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
