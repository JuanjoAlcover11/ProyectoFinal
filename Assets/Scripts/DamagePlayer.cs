using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int hitSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //We call the function "Damage"
            HealthManager.instance.Damage();
            //We play the sound
            AudioManager.instance.PlaySFX(hitSound);
        }
    }
}
