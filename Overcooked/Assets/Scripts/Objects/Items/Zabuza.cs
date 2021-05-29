using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zabuza : MonoBehaviour
{


    private Vector3 original_pos;
    private Quaternion original_rotation;

    private AudioSource audioSource;
    private Animator animator;
    private GameObject NarutoRightHand;
    private GameObject Naruto;
    private bool firstCut;

    // Start is called before the first frame update
    void Start()
    {
        original_pos = transform.position;
        original_rotation = transform.rotation;

        audioSource = GetComponent<AudioSource>();
        
        NarutoRightHand = GameObject.FindWithTag("RightHand");
        Naruto = GameObject.FindWithTag("Player");

        animator = Naruto.GetComponent<Animator>();
        firstCut = true;

    }

    // Update is called once per frame
    void Update()
    {

        if(animator.GetBool("isCutting"))
        {
            if(firstCut){
                transform.Rotate(-90, 0, 90);
                firstCut = false;
            }
            transform.position = NarutoRightHand.transform.position;
        }

        else
        {
            transform.position = original_pos;
            transform.rotation = original_rotation;
            firstCut = true;
        }
    }
}
