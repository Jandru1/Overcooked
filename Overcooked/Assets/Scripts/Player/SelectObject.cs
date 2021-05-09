using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    public float castDistance = 1.2f;
    private Collider m_Collider;
    private GameObject lookingAtObject;
    private GameObject selectedObject;
    public bool carryingObject;
    private Animator animator;


    void Start(){

        animator = GetComponent<Animator>();
        m_Collider = GetComponent<Collider>();
        lookingAtObject = null;
        selectedObject = null;
        carryingObject = false;
    }
    void Update()
    {
        RaycastHit hit;
        Vector3 scale = transform.localScale;
        scale.y *= 2;

        // Look at Object logic:
        if (Physics.BoxCast(m_Collider.bounds.center, scale, transform.forward, out hit, transform.rotation, castDistance)){
            lookingAtObject = hit.transform.gameObject;
        } else {
            lookingAtObject = null;
        }
        if(lookingAtObject != null)
            Debug.Log("Looking at: " + lookingAtObject.name + " " + lookingAtObject.tag);

        if(Input.GetKeyUp(KeyCode.Space)){ // Pick or drop object with spacebar
            if(lookingAtObject != null && lookingAtObject.tag == "Selectable"){  // Pick up object
                selectedObject = lookingAtObject;
                selectedObject.GetComponent<PickUpObject>().Select();
                carryingObject = true;
            }
            else if (carryingObject){  // Drop object
                selectedObject.GetComponent<PickUpObject>().Unselect();
                selectedObject = null;
                carryingObject = false;
            }
        }

        if (carryingObject) animator.SetBool("isCarrying", true);
        else animator.SetBool("isCarrying", false);

    }
}
