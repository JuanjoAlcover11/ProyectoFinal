using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public int rutine;
    public float crono;
    public Animator enemyAnimator;
    public Quaternion angle;
    public float angleX;

    public GameObject target;
    public bool isAttacking;

    public float enemyHealth;

    public GameObject enemyEffect;
    public GameObject enemyCoinEffect;
    public GameObject enemyHit;

    public BoxCollider colliderWeapon;
    private GameObject enemyWeapon;

    public int value = 1;
    public int enemyHitSound;
    public int enemyAttackSound;
    public int enemyDeathSound;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        target = GameObject.Find("Player1");
        //The collider of the enemy attack stops working
        colliderWeapon.enabled = false;
    }

    private void Attackstart()
    {
        //The collider of the enemy attack starts working
        colliderWeapon.enabled = true;
        AudioManager.instance.PlaySFX(enemyAttackSound);
    }
    private void AttackEnd()
    {
        //The collider of the enemy attack stops working
        colliderWeapon.enabled = false;
    }

    private void LateUpdate()
    {
        //The boolean "Attack 01" changes its value depending on "isAttacking"
        enemyAnimator.SetBool("Attack 01", isAttacking);
    }

    public void EnemyBehaviour()
    {
        //If the enemy is not close to the enemy...
        if (Vector3.Distance(transform.position, target.transform.position) > 10)
        {
            //The boolean "Run Forward" changes its value depending to false
            enemyAnimator.SetBool("Run Forward", false);
            crono += 1 * Time.deltaTime;
            isAttacking = false;
            
            //The enemy has a rutine in which he has different posible behaviours/movement
            if (crono >= 4)
            {
                rutine = Random.Range(0, 2);
                crono = 0;
            }
            switch (rutine)
            {
                case 0:
                    enemyAnimator.SetBool("Walk Forward", false);
                    break;
                case 1:
                    angleX = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, angleX, 0);
                    rutine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    enemyAnimator.SetBool("Walk Forward", true);
                    break;
            }
        }
        else
        {
            //If the enemy is in a certain distance from the player...
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !isAttacking)
            {
                //The enemy starts chasing the player
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                enemyAnimator.SetBool("Walk Forward", false);

                enemyAnimator.SetBool("Run Forward", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                isAttacking = false;
            }
            else
            //The enemy attacks
            {
                enemyAnimator.SetBool("Walk Forward", false);
                enemyAnimator.SetBool("Run Forward", false);

                isAttacking = true;
            }
        }
    }

    public void FinalAni()
    {
        //The attack animation ends
        enemyAnimator.SetBool("Attack 01", false);
        isAttacking = false;
    }

    public void FinalAni2()
    {
        //The getting damage animation ends
        enemyAnimator.SetBool("Damage", false);
    }

    public void enemyDamage()
    {
        //The enemy loses health when it gets hit
        enemyHealth--;
        //We play the sound
        AudioManager.instance.PlaySFX(enemyHitSound);
        //We instantiate the particle
        Instantiate(enemyHit, transform.position, transform.rotation);

        if (enemyHealth <= 0)
        {
            //If the enemy health gets to 0, we instantiate the respective particles and sound and the enemy gets destroy
            Instantiate(enemyEffect, transform.position, transform.rotation);
            Instantiate(enemyCoinEffect, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(enemyDeathSound);
            //We call the function "addPoints"
            GameManager.instance.addPoints(value);
            Destroy(gameObject);
        }
        else
        {
            enemyAnimator.SetBool("Attack 01", false);
            //If the enemy doesn't die, the take damage animation starts
            enemyAnimator.SetBool("Damage", true);
            isAttacking = false;
        }

    }


    void Update()
    {
        EnemyBehaviour();
    }
}
