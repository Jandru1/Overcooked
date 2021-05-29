using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olla : Interactable
{
    private GameObject Fire;

    void Start()
    {
        Fire = transform.Find("Fire").gameObject;
        Fire.gameObject.SetActive(false);
    }

    public override void StartInteraction(GameObject standTrigger)
    {
        interacting = true;
        stand = standTrigger;
        Fire.gameObject.SetActive(true);
        courtine = Interaction();
        StartCoroutine(courtine);
    }

    
    public override void StopInteraction()
    {
        interacting = false;
        stand.GetComponent<DefaultStandBehaviour>().finishedInteracting();
        Fire.gameObject.SetActive(false);
    }
}
