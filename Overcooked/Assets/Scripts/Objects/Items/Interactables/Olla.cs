using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olla : Interactable
{
    private GameObject Fire;
    public bool isBurning;
    public bool cooked;
    public GameObject insidePrefab;


    void Awake()
    {
        Fire = transform.Find("Fire").gameObject;
        Fire.gameObject.SetActive(false);
        isBurning = false;
        cooked = false;
    }

    public void StartFire(){
        Fire.gameObject.SetActive(true);
        isBurning = true;
    }

    
    public void StopFire(){
        Fire.gameObject.SetActive(false);
        isBurning = false;
    }

    public override void StartInteraction(GameObject standTrigger)
    {
        if(!isBurning)
            StartFire();
        if(GetComponent<Identifiers>().id != "Olla"){
            interacting = true;
            stand = standTrigger;
            courtine = Interaction();
            StartCoroutine(courtine);
        }
    }
    
    public override void StopInteraction()
    {
        cooked = true;
        interacting = false;
        stand.GetComponent<DefaultStandBehaviour>().finishedInteracting();
    }

    public void InterruptInteraction()
    {
        cooked = false;
        interacting = false;
        stand.GetComponent<DefaultStandBehaviour>().finishedInteracting();
        StopFire();
        StopCoroutine(courtine);
    }

    public GameObject GetInside(){
        return Instantiate(insidePrefab);
    }
}
