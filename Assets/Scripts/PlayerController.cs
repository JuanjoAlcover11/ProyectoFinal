using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public float jumpForce;
    public float rotateSpeed;
    public float gravityScale = 3f;

    public CharacterController charController;
    public Camera playerCamera;
    public GameObject playerModel;

    public Animator animator;

    private Vector3 moveDirection;

    public bool isKnocking;
    public float knockBackLength = 0.5f;
    private float knockBackCounter;
    public Vector2 knockBackPower;

    public GameObject[] playerParts;

    private bool isAttacking;

    private bool isGameOver;

    public int jumpSound;
    public int swordSound;
    public int deathSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            //If the instance already exists, we destroy it
            Destroy(gameObject);
        }
    }

    void Start()
    {
        isGameOver = false;
    }

    void Update()
    {
        isAttacking = false;

        if (isGameOver == false)
        {
            if (charController.isGrounded && moveDirection.y < 0)
            {
                moveDirection.y = -1.0f;
                //Salto del personaje
                if (Input.GetKeyDown("space"))
                {
                    moveDirection.y = jumpForce;
                    AudioManager.instance.PlaySFX(jumpSound);
                }
            }
            else
            {
                //Fisicas de la gravedad
                moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
            }

            if (!isKnocking)
            {
                //Movimiento del personaje
                float yStore = moveDirection.y;
                moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
                moveDirection.Normalize();
                moveDirection = moveDirection * moveSpeed;
                moveDirection.y = yStore;
                charController.Move(moveDirection * Time.deltaTime);

                if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                {
                    transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
                    Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
                    playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    //Ataque
                    isAttacking = true;
                    //The sound only plays if the game isn't paused
                    if (Time.timeScale == 1)
                    {
                        AudioManager.instance.PlaySFX(swordSound);
                    }
                }

            }
            else if (isKnocking)
            {
                //When the player gets hit, he has some recoil
                knockBackCounter -= Time.deltaTime;

                float yStore = moveDirection.y;
                moveDirection = (playerModel.transform.forward * knockBackPower.x);
                moveDirection.y = yStore;

                moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

                charController.Move(moveDirection * Time.deltaTime);

                if (knockBackCounter <= 0)
                {
                    isKnocking = false;
                }
            }
            //We set the speed of the player for the float that controls the running animation
            animator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
            //We set the boolean "isGrounded" that controls the jumping animation
            animator.SetBool("isGrounded", charController.isGrounded);

        }
    }
    
    public void Knockback()
    {
        //The recoil/knockback values
        isKnocking = true;
        knockBackCounter = knockBackLength;
        moveDirection.y = knockBackPower.y;
        charController.Move(moveDirection * Time.deltaTime);
    }

    private void LateUpdate()
    {
        //The boolean "isAttacking" changes its value depending on "isAttacking"
        animator.SetBool("isAttacking", isAttacking);
    }

    public void PlayerDeath()
    {
        //We make the boolean "isgameover" true and we play the death audio
        isGameOver = true;
        AudioManager.instance.PlaySFX(deathSound);
    }
}
