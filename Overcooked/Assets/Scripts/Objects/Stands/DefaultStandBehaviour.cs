using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultStandBehaviour : MonoBehaviour
{
    public bool hasItemOnTop;
    public GameObject itemOnTop;
    public bool hasPickableObject;
    public bool interacting;
    public bool isBlocking;

    
    protected Shader outlineShader;
    protected Shader previousShader;
    protected Collider m_Collider;
    protected Vector3 topPos;

    virtual protected void Start(){
        //Stand initializations:
        m_Collider = GetComponent<Collider>();
        topPos = new Vector3(m_Collider.bounds.center.x, m_Collider.bounds.max.y + 0.01f, m_Collider.bounds.center.z);

        //Top item initializations:
        if(itemOnTop != null){
            hasItemOnTop = true;
            hasPickableObject = itemOnTop.CompareTag("Pickable");
            if(hasPickableObject)
                PlaceItem(itemOnTop);
        } else {
            hasItemOnTop = false;
        }

        //Top item interaction initializations:
        interacting = false;

        //Highlight initializations:
        previousShader = null;
        outlineShader = Shader.Find("Outlined/Outline");
    }

    virtual public bool PlaceItem(GameObject newItem){
        hasItemOnTop = true;
        hasPickableObject = newItem.CompareTag("Pickable");
        itemOnTop = newItem;
        itemOnTop.GetComponent<PickUpObject>().Place(topPos);
        return true;
    }

    virtual public bool CombineItems(GameObject newItem){
        if(itemOnTop.GetComponent<CuttingTable>() != null){
            hasPickableObject = itemOnTop.GetComponent<CuttingTable>().PutItem(newItem);
            return hasPickableObject;
        }
        GameObject controller = GameObject.FindWithTag("LevelController");
        GameObject combined = controller.GetComponent<Combiner>().Combine(itemOnTop, newItem);
        if(combined != null){
            PlaceItem(combined);
            return true;
        }
        return false;
    }

    virtual public GameObject GrabItem(){
        hasPickableObject = false;
        if(itemOnTop.GetComponent<CuttingTable>() != null){
            return itemOnTop.GetComponent<CuttingTable>().TakeItem();
        }
        hasItemOnTop = false;
        itemOnTop.GetComponent<PickUpObject>().PickUp();
        GameObject lastItem = itemOnTop;
        itemOnTop = null;
        return lastItem;
    }

    public void Highlight(){
        previousShader = GetComponent<Renderer>().material.shader;
        GetComponent<Renderer>().material.shader = outlineShader;
        GetComponent<AudioSource>().Play(0);
    }

    public void UnHighlight(){
        GetComponent<Renderer>().material.shader = previousShader;
        previousShader = null;
    }

    public void startInteraction(){
        if(itemOnTop.GetComponent<Interactable>() != null) { // If the object is interactable
            itemOnTop.GetComponent<Interactable>().StartInteraction(gameObject);
            interacting = true;
            isBlocking = itemOnTop.GetComponent<Interactable>().isBlocking;
        }
    }

    public void finishedInteracting(){
        interacting = false;
    }
}
