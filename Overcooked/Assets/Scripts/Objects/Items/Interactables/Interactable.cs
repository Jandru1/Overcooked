using System.Collections;
using System.Collections.Generic;
using UnityEngine;
abstract public class Interactable : MonoBehaviour
{
    public float interactionTimeNeeded;
    
    public bool interacting;
    public bool isBlocking = false;
    public GameObject loadBar;

    protected GameObject stand;
    protected IEnumerator courtine;
    public virtual void  StartInteraction(GameObject standTrigger)
    {
        interacting = true;
        stand = standTrigger;
        courtine = Interaction();
        StartCoroutine(courtine);
    }

    public virtual void StopInteraction()
    {
        interacting = false;
        stand.GetComponent<DefaultStandBehaviour>().finishedInteracting();
        StopCoroutine(courtine);
    }

    protected IEnumerator Interaction()
    {
        loadBar.SetActive(true);
        loadBar.GetComponent<LoadBar>().StartInteraction();
        while(true){
            yield return new WaitForSeconds(interactionTimeNeeded);
            StopInteraction();
            StopCoroutine(courtine);
        }
    }
}