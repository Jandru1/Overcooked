using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultStandBehaviour : MonoBehaviour
{
    public bool hasItemOnTop;
    public GameObject itemOnTop;

    
    private Shader outlineShader;
    private Shader previousShader;
    private Collider m_Collider;
    private Vector3 topPos;

    void Start(){
        //Stand initializations:
        m_Collider = GetComponent<Collider>();
        topPos = new Vector3(m_Collider.bounds.center.x, m_Collider.bounds.max.y + 0.01f, m_Collider.bounds.center.z);

        //Top item initializations:
        if(itemOnTop != null){
            hasItemOnTop = true;
            PlaceItem(itemOnTop);
        }

        //Highlight initializations:
        previousShader = null;
        outlineShader = Shader.Find("Outlined/Outline");
    }

    public void PlaceItem(GameObject newItem){
        hasItemOnTop = true;
        itemOnTop = newItem;
        itemOnTop.GetComponent<PickUpObject>().Place(topPos);
    }

    public GameObject GrabItem(){
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
}
