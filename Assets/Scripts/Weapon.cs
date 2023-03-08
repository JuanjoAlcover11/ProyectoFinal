using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    BoxCollider colliderWeapon;
    private GameObject weapon;
    public Transform pivotWeapon;

    void Start()
    {
        //We get the weapon gameObject
        weapon = pivotWeapon.GetChild(1).gameObject;
        colliderWeapon = weapon.GetComponent<BoxCollider>();

        colliderWeapon.enabled = false;

    }
   
    private void Attackstart()
    {
        //The weapon collider activates
        colliderWeapon.enabled = true;
    }
    private void AttackEnd()
    {
        //The weapon collider deactivates
        colliderWeapon.enabled = false;
    }
}
