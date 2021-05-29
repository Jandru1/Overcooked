using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingTable : Interactable
{
    
    private Animator narutoAnimator;
    void Start()
    {
        isBlocking = true;
        narutoAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    public override void StartInteraction(GameObject standTrigger)
    {
        interacting = true;
        stand = standTrigger;
        narutoAnimator.SetBool("isCutting", true);
        courtine = Interaction();
        GetComponent<AudioSource>().Play();
        StartCoroutine(courtine);
    }

    
    public override void StopInteraction()
    {
        interacting = false;
        stand.GetComponent<DefaultStandBehaviour>().finishedInteracting();
        narutoAnimator.SetBool("isCutting", false);
        GetComponent<AudioSource>().Stop();
    }
}
