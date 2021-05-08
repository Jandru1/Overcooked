using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNaruto : MonoBehaviour
{

    public float walkSpeed = 2.0f;
    public float dashSpeed = 5.0f;
    public float rotationSpeed = 100.0f;

    public float horizontalMove;
    public float VerticalMove;

    public ParticleSystem runningDust;
    private Animator animator;
    private CharacterController controller;
    private bool isGrounded;
    private Vector3 playerInput;
    private Vector3 movePlayer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
  
        horizontalMove = Input.GetAxis("Horizontal");
        VerticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, VerticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        movePlayer = playerInput;

        controller.transform.LookAt(controller.transform.position + playerInput);
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // Left move
        {
            animator.SetBool("isWalking", true);
            //controller.transform.Rotate(new Vector3(0.0f, -rotationSpeed*Time.deltaTime, 0.0f));
            //controller.transform.TransformDirection(0.0f, -rotationSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // Right move
        {
            animator.SetBool("isWalking", true);

            //controller.transform.Rotate(new Vector3(0.0f, +rotationSpeed * Time.deltaTime, 0.0f));
            //controller.transform.TransformDirection(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) // Forward move
        {
            animator.SetBool("isWalking", true);

            //controller.transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            //controller.transform.TransformDirection(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) // Backward move
        {
            animator.SetBool("isWalking", true);

            //controller.transform.Rotate(-rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            //controller.transform.TransformDirection(-rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isRunning", false);

        }
        if (Input.GetKey(KeyCode.Space)) animator.SetBool("isRunning", true);

        if (animator.GetBool("isRunning")) controller.Move(playerInput * dashSpeed * Time.deltaTime);
        else controller.Move(playerInput * walkSpeed * Time.deltaTime);


        /*
        Vector3 move = new Vector3(0, controller.isGrounded ? 0 : -10, 0);

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // Left move
        {
            controller.transform.Rotate(0.0f,  -rotationSpeed * Time.deltaTime, 0.0f);
            controller.transform.TransformDirection(0.0f,  -rotationSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // Right move
        {
            controller.transform.Rotate(0.0f,  rotationSpeed * Time.deltaTime, 0.0f);
            controller.transform.TransformDirection(0.0f,  rotationSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) // Forward move
        {   
            if (Input.GetKey(KeyCode.Space) && animator.GetBool("isWalking")) // Naruto-run
            {
                if(!runningDust.isPlaying)
                    runningDust.Play();
                animator.SetBool("isRunning", true);
                //transform.Translate(0.0f, 0.0f, dashSpeed * Time.deltaTime);
            } else {  // Normal Walk
                runningDust.Stop();
                animator.SetBool("isWalking", true);
                animator.SetBool("isWalkingBack", false);
                animator.SetBool("isRunning", false);
                move.z += walkSpeed;
                //transform.Translate(0.0f,  0.0f, walkSpeed * Time.deltaTime);
            }
        } else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) // Backward move
        {   
            runningDust.Stop();
            animator.SetBool("isWalkingBack", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            move.z -= walkSpeed;
            //transform.Translate(0.0f,  0.0f, -walkSpeed * Time.deltaTime);
        }
        else {
            runningDust.Stop();
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingBack", false);
        }

        controller.Move(move * Time.deltaTime);
        */
    }

}