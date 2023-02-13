using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public static EnemyAI instance;

    public int rutine;
    public float crono;
    public Animator enemyAnimator;
    public Quaternion angle;
    public float angleX;

    public GameObject target;
    public bool isAttacking;

    public float enemyHealth;

    public GameObject enemyEffect;

    public BoxCollider colliderWeapon;
    private GameObject enemyWeapon;

    public GameObject itemDrop;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        target = GameObject.Find("Player1");

        //colliderWeapon = enemyWeapon.GetComponent<BoxCollider>();

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

    public void EnemyBehaviour()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            enemyAnimator.SetBool("Run Forward", false);
            crono += 1 * Time.deltaTime;
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
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !isAttacking)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                enemyAnimator.SetBool("Walk Forward", false);

                enemyAnimator.SetBool("Run Forward", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                enemyAnimator.SetBool("Attack 01", false);
            }
            else
            {
                enemyAnimator.SetBool("Walk Forward", false);
                enemyAnimator.SetBool("Run Forward", false);
                enemyAnimator.SetBool("Attack 01", true);
                isAttacking = true;
            }
        }
    }

    public void FinalAni()
    {
        enemyAnimator.SetBool("Attack 01", false);
        isAttacking = false;
    }

    public void enemyDamage()
    {
        enemyHealth--;

        if (enemyHealth <= 0)
        {
            Instantiate(enemyEffect, transform.position, transform.rotation);
            Instantiate(itemDrop, transform.position, angle);
            Destroy(gameObject);
        }

    }


    void Update()
    {
        EnemyBehaviour();
    }
}
