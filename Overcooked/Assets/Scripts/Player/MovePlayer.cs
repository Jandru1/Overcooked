using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlayer : MonoBehaviour
{

    public float walkSpeed = 2.6f;
    public float dashSpeed = 9.0f;
    public float dashTime = 0.4f;
    public float dashReloadTime = 3.0f;
    public ParticleSystem runningDust;

    public bool isInRange;
    public KeyCode interactKey;

    private Animator animator;
    private CharacterController controller;
    private float playerSpeed;
    private Vector3 dashDirection;
    private float dashCount;
    private float dashReloadCount;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        playerSpeed = walkSpeed;
        dashCount = 0.0f;
        dashReloadCount = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                Debug.Log("Animamos");

                Animamos();
              //  StartCoroutine(Acortar());
            }
        }

        //Movement:
        float horizontalMove = Input.GetAxis("Horizontal");
        float VerticalMove = Input.GetAxis("Vertical");

        Vector3 playerInput = new Vector3(horizontalMove, 0, VerticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        if(!animator.GetBool("isDashing"))
            controller.transform.LookAt(controller.transform.position + playerInput);
        
        // Animations and dash:
        if(animator.GetBool("isWalking") && (Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftAlt)) 
            && dashReloadCount == 0.0f && !animator.GetBool("isCarrying")) { // Start Dash
            animator.SetBool("isDashing", true);
            animator.SetBool("isWalking", false);
            runningDust.Play();
            playerSpeed = dashSpeed;
            dashDirection = new Vector3(playerInput.x > 0 ? 1 : playerInput.x < 0 ? -1 : 0, 
                                        playerInput.y > 0 ? 1 : playerInput.y < 0 ? -1 : 0, 
                                        playerInput.z > 0 ? 1 : playerInput.z < 0 ? -1 : 0); 
            controller.transform.LookAt(controller.transform.position + dashDirection);

        } else if (animator.GetBool("isDashing")){ 
            if (dashCount < dashTime && !(controller.collisionFlags == CollisionFlags.Sides)){ // Count the time on the dash
                playerInput = dashDirection;
                dashCount += Time.deltaTime;
            } else { // End dash
                animator.SetBool("isDashing", false);
                animator.SetBool("isWalking", true);
                runningDust.Stop();
                playerSpeed = walkSpeed;
                dashCount = 0;
                dashReloadCount = dashReloadTime;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) // Left move
            || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) // Right move
            || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) // Forward move
            || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) // Backward move
            {
                dashReloadCount = Math.Max(dashReloadCount - Time.deltaTime, 0.0f);
                animator.SetBool("isWalking", true);
            }

        else { // Idle

            dashReloadCount = Math.Max(dashReloadCount - Time.deltaTime, 0.0f);
            animator.SetBool("isDashing", false);
            animator.SetBool("isWalking", false);
        }


        
        if(!controller.isGrounded)  // Fall
            playerInput.y -= 10;
        
        // Move:
        controller.Move(playerInput * playerSpeed * Time.deltaTime);


    }

    private void Animamos()
    {
        animator.SetBool("isCutting", true);
        StartCoroutine(ThreeSeconds());
    }

    IEnumerator ThreeSeconds()
    {
        yield return new WaitForSeconds(3);
        animator.SetBool("isCutting", false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            isInRange = true;
            Debug.Log("Naurto now in range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            isInRange = false;
            Debug.Log("Naruto now NOT in range");
        }
    }

    IEnumerator Acortar()
    {
        animator.SetBool("isCutting", true);
        yield return new WaitForSeconds(3);
        animator.SetBool("isCutting", false);
        Debug.Log("Wait is over");
    }
}