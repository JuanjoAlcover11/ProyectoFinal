using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    private int value = 1;

    public GameObject coinEffect;

    public int coinSound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.addPoints(value);
            Destroy(gameObject);
            Instantiate(coinEffect, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(coinSound);
        }
    }
}
