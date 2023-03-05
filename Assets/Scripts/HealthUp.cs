using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    public int healAmount;
    public bool isHealthFull;

    public GameObject heartParticle;

    public int heartSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);

            Instantiate(heartParticle, PlayerController.instance.transform.position + new Vector3(0f, 1f, 0f), PlayerController.instance.transform.rotation);

            AudioManager.instance.PlaySFX(heartSound);

            if (isHealthFull)
            {
                HealthManager.instance.ResetHealth();
            }
            else
            {
                HealthManager.instance.AddHealth(healAmount);
            }
        }
    }
}
