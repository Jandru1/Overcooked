using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Transform destinationPos;

    public bool onFloor;
    private bool beingCarried;
    void Start(){
        destinationPos = GameObject.FindWithTag("pickedObjLoc").transform;
        onFloor = false;
        beingCarried = false;
    }
    void Update() {
        if(beingCarried)
            this.transform.position = destinationPos.position;
    }
    public void PickUp()
    {
        this.transform.position = destinationPos.position;
        Quaternion rotation = Quaternion.LookRotation(this.transform.forward, Vector3.up);
        this.transform.rotation = rotation;
        this.transform.parent = GameObject.Find("pickedObjectLocation").transform;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        if(onFloor){
            onFloor = false;
            this.transform.localScale /= 1.3f;
        }
        beingCarried = true;
        GetComponent<AudioSource>().Play(0);
    }
    public void Drop() {
        this.transform.localScale *= 1.3f;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = false;
        this.transform.parent = null;
        onFloor = true;
        beingCarried = false;
    }

    public void Place(Vector3 finalPos){
        this.transform.parent = null;
        this.transform.position = finalPos;
        Quaternion rotation = Quaternion.LookRotation(this.transform.forward, Vector3.up);
        this.transform.rotation = rotation;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = true;
        beingCarried = false;
    }

}
