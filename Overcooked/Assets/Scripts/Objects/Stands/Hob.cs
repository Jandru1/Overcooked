using UnityEngine;

public class Hob : DefaultStandBehaviour
{
    public GameObject OllaPrefab;
    
    override public bool PlaceItem(GameObject newItem){  // Solo permitir ollas
        string objectID = newItem.GetComponent<Identifiers>().id;
        if(objectID.Contains("Olla")){
            Destroy(itemOnTop);
            hasItemOnTop = true;
            hasPickableObject = newItem.CompareTag("Pickable");
            itemOnTop = newItem;
            itemOnTop.GetComponent<PickUpObject>().Place(topPos);
            itemOnTop.GetComponent<Olla>().StartInteraction(gameObject);
            return true;
        }
        return false;
    }

    override public GameObject GrabItem(){
        if(hasItemOnTop && itemOnTop.GetComponent<Olla>().cooked){
            GameObject itemInside = itemOnTop.GetComponent<Olla>().GetInside();
            PlaceItem(Instantiate(OllaPrefab));
            itemInside.GetComponent<PickUpObject>().PickUp();
            return itemInside;
        } else if (hasItemOnTop && itemOnTop.GetComponent<Identifiers>().id != "Olla" && !itemOnTop.GetComponent<Olla>().cooked) {
            hasItemOnTop = false;
            hasPickableObject = false;
            itemOnTop.GetComponent<PickUpObject>().PickUp();
            itemOnTop.GetComponent<Olla>().InterruptInteraction();
            GameObject lastItem = itemOnTop;
            itemOnTop = null;
            return lastItem;
        }else {
            hasItemOnTop = false;
            hasPickableObject = false;
            itemOnTop.GetComponent<PickUpObject>().PickUp();
            itemOnTop.GetComponent<Olla>().StopFire();
            GameObject lastItem = itemOnTop;
            itemOnTop = null;
            return lastItem;
        }
    }

    override public bool CombineItems(GameObject newItem){
        GameObject controller = GameObject.FindWithTag("LevelController");
        GameObject combined = controller.GetComponent<Combiner>().Combine(itemOnTop, newItem);
        if(combined != null){
            PlaceItem(combined);
            return true;
        }
        return false;
    }
}
