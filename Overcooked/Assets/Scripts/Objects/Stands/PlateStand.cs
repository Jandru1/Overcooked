using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateStand : DefaultStandBehaviour
{
    public GameObject PlatePrefab;
    public override GameObject GrabItem(){
        hasItemOnTop = true;
        GameObject lastItem = itemOnTop;
        GameObject newPlate = Instantiate(PlatePrefab);
        newPlate.GetComponent<PickUpObject>().destinationPos = lastItem.GetComponent<PickUpObject>().destinationPos;
        itemOnTop.GetComponent<PickUpObject>().PickUp();
        PlaceItem(newPlate);
        return lastItem;
    }
}
