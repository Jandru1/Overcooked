using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxProvider : DefaultStandBehaviour
{
    public GameObject FoodPrefab;
    protected override void Start(){
        //Stand initializations:
        m_Collider = GetComponent<Collider>();
        topPos = new Vector3(m_Collider.bounds.center.x, m_Collider.bounds.max.y + 0.01f, m_Collider.bounds.center.z);

        //Top item initializations:
        itemOnTop = Instantiate(FoodPrefab);
        hasItemOnTop = true;
        hasPickableObject = true;
        PlaceItem(itemOnTop);
        itemOnTop.GetComponent<Renderer>().enabled = false;

        //Top item interaction initializations:
        interacting = false;

        //Highlight initializations:
        previousShader = null;
        outlineShader = Shader.Find("Outlined/Outline");
    }
    public override GameObject GrabItem(){
        hasItemOnTop = true;
        GameObject lastItem = itemOnTop;
        itemOnTop.GetComponent<Renderer>().enabled = true;
        GameObject newFood = Instantiate(FoodPrefab);
        newFood.GetComponent<PickUpObject>().destinationPos = lastItem.GetComponent<PickUpObject>().destinationPos;
        itemOnTop.GetComponent<PickUpObject>().PickUp();
        newFood.GetComponent<Renderer>().enabled = false;
        PlaceItem(newFood);
        return lastItem;
    }
}
