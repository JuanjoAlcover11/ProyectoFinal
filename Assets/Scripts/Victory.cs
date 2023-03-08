using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{ 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.saveContador();
            //We hide the cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //We change to the "You win" scene
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
