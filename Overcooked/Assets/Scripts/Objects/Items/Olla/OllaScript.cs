using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OllaScript : MonoBehaviour
{
    private GameObject Fire;
    private Animator animator;

    private bool isInRange;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        Fire = GameObject.FindWithTag("OllaFire");
        Fire.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("isBurning", true);
                StartCoroutine(Cocinamos());
            }
        }
        if (animator.GetBool("isBurning"))
        {
            Fire.gameObject.SetActive(true);
        }
        else
        {
            Fire.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Naruto now in range with olla");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Naruto now NOT in range with olla");
        }
    }

    IEnumerator Cocinamos()
    {
        yield return new WaitForSeconds(5);
        animator.SetBool("isBurning", false);
    }
}
