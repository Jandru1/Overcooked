using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNaruto : MonoBehaviour
{

    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // Left move
        {
            transform.Rotate(0.0f,  rotationSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // Right move
        {
            transform.Rotate(0.0f,  -rotationSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) // Forward move
        {   
            if (Input.GetKey(KeyCode.Space)) // Naruto-run
            {
                animator.SetBool("isRunning", true);
                transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
            } else {
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
                transform.Translate(-speed * Time.deltaTime, 0.0f,  0.0f);
            }
        }
        else {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
        }
    }
}
