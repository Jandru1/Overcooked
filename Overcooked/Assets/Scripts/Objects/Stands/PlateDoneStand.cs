using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateDoneStand : DefaultStandBehaviour
{
    override public bool PlaceItem(GameObject newItem){
        if(GameObject.FindWithTag("PlateInstantiator").GetComponent<PlateInstantiate>().DonePlate(newItem.GetComponent<Identifiers>().id)){
            Destroy(newItem);
            return true;
        }
        return false;
    }
}