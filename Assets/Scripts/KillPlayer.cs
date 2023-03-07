using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //The player gets killed and we change to the scene "gameover"
            GameManager.instance.GameOver();
            PlayerController.instance.PlayerDeath();
        }
    }
}
