using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        //When the player touches the platforms, it becomes it's child
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //The player is no longer the platform's child
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
