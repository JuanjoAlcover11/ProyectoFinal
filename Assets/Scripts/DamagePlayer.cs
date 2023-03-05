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
            HealthManager.instance.Damage();
            AudioManager.instance.PlaySFX(hitSound);
        }
    }
}
