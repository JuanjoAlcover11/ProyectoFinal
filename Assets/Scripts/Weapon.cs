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
        weapon = pivotWeapon.GetChild(1).gameObject;
        colliderWeapon = weapon.GetComponent<BoxCollider>();

        colliderWeapon.enabled = false;

    }
   
    private void Attackstart()
    {
        colliderWeapon.enabled = true;
    }
    private void AttackEnd()
    {
        colliderWeapon.enabled = false;
    }
}
