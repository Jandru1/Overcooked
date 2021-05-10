using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Transform destinationPos;

    public void PickUp()
    {
        this.transform.position = destinationPos.position;
        Quaternion rotation = Quaternion.LookRotation(this.transform.forward, Vector3.up);
        this.transform.rotation = rotation;
        this.transform.parent = GameObject.Find("pickedObjectLocation").transform;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().freezeRotation = true;
    }
    public void Drop() {
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = false;
        this.transform.parent = null;
    }

    public void Place(Vector3 finalPos){
        this.transform.parent = null;
        this.transform.position = finalPos;
        Quaternion rotation = Quaternion.LookRotation(this.transform.forward, Vector3.up);
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = true;
    }
}
