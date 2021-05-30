using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingTable : Interactable
{
    
    private Animator narutoAnimator;
    private GameObject itemOnTop;
    private bool hasItemOnTop;
    protected Vector3 topPos;
    void Start()
    {
        isBlocking = true;
        itemOnTop = null;
        hasItemOnTop = false;
        narutoAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        Collider m_Collider = GetComponent<Collider>();
        topPos = new Vector3(m_Collider.bounds.center.x, m_Collider.bounds.max.y + 0.01f, m_Collider.bounds.center.z);
    }

    public bool PutItem(GameObject newItem){
        if(hasItemOnTop)
            return false;
        if(GameObject.FindWithTag("LevelController").GetComponent<Combiner>().IsCuttable(newItem.GetComponent<Identifiers>().id)){
            hasItemOnTop = true;
            itemOnTop = newItem;
            itemOnTop.GetComponent<PickUpObject>().Place(topPos);
            return true;
        }
        return false;
    }

    public GameObject TakeItem(){
        if(!hasItemOnTop)
            return null;
        itemOnTop.GetComponent<PickUpObject>().PickUp();
        GameObject lastItem = itemOnTop;
        hasItemOnTop = false;
        itemOnTop = null;
        return lastItem;
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
        itemOnTop = GameObject.FindWithTag("LevelController").GetComponent<Combiner>().Cortar(itemOnTop);
        itemOnTop.GetComponent<PickUpObject>().Place(topPos);
    }
}
