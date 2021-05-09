using System.Diagnostics;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlayer : MonoBehaviour
{

    public float walkSpeed = 2.0f;
    public float dashSpeed = 5.0f;
    public int dashSteps = 175;
    public int dashReload = 500;
    public ParticleSystem runningDust;


    private Animator animator;
    private CharacterController controller;
    private float playerSpeed;
    private Vector3 dashDirection;
    private int dashCount;
    private int dashReloadCount;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        playerSpeed = walkSpeed;
        dashCount = 0;
        dashReloadCount = dashReload;
    }

    // Update is called once per frame
    void Update()
    {

        //Movement:
        float horizontalMove = Input.GetAxis("Horizontal");
        float VerticalMove = Input.GetAxis("Vertical");

        Vector3 playerInput = new Vector3(horizontalMove, 0, VerticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        if(!animator.GetBool("isDashing"))
            controller.transform.LookAt(controller.transform.position + playerInput);
        
        // Animations and dash:
        if(animator.GetBool("isWalking") && (Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftAlt)) 
            && dashReloadCount >= dashReload) { // Start Dash
            animator.SetBool("isDashing", true);
            animator.SetBool("isWalking", false);
            runningDust.Play();
            playerSpeed = dashSpeed;
            dashDirection = new Vector3(playerInput.x > 0 ? 1 : playerInput.x < 0 ? -1 : 0, 
                                        playerInput.y > 0 ? 1 : playerInput.y < 0 ? -1 : 0, 
                                        playerInput.z > 0 ? 1 : playerInput.z < 0 ? -1 : 0); 
            controller.transform.LookAt(controller.transform.position + dashDirection);

        } else if (animator.GetBool("isDashing")){ 
            if (dashCount < dashSteps){ // Count the time on the dash
                playerInput = dashDirection;
                ++dashCount;
            } else { // End dash
                animator.SetBool("isDashing", false);
                animator.SetBool("isWalking", true);
                runningDust.Stop();
                playerSpeed = walkSpeed;
                dashCount = 0;
                dashReloadCount = 0;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) // Left move
            || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) // Right move
            || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) // Forward move
            || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) // Backward move
            {
                ++dashReloadCount;
                animator.SetBool("isWalking", true);
            }

        else { // Idle
            ++dashReloadCount;
            animator.SetBool("isDashing", false);
            animator.SetBool("isWalking", false);
        }


        
        if(!controller.isGrounded)  // Fall
            playerInput.y -= 10;
        
        // Move:
        controller.Move(playerInput * playerSpeed * Time.deltaTime);
    }
}