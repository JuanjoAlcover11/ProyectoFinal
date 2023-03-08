using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            //The enemy gets hit when it touches the collider of the sword
            other.gameObject.GetComponent<EnemyAI>().enemyDamage();
        }
    }
}
