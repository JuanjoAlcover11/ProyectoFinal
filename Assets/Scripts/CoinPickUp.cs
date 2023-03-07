using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    private int value = 1;

    public GameObject coinEffect;

    public int coinSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //We call the function "addPoints"
            GameManager.instance.addPoints(value);
            //The coin gets destroyed
            Destroy(gameObject);
            //We instantiate the particle
            Instantiate(coinEffect, transform.position, transform.rotation);
            //We play the sound
            AudioManager.instance.PlaySFX(coinSound);
        }
    }
}
