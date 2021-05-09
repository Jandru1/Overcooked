using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    public float castDistance = 1f;
    private Collider m_Collider;
    private GameObject lookingAtObject;
    private GameObject selectedObject;
    private bool carryingObject;

    Shader outlineShader;
    Shader previousShader;

    void Start(){
        m_Collider = GetComponent<Collider>();
        outlineShader = Shader.Find("Outlined/Outline");
        lookingAtObject = null;
        selectedObject = null;
        carryingObject = false;
    }
    void Update()
    {
        RaycastHit hit;

        // Look at Object logic:
        Vector3 scale = transform.localScale;
        scale.y *= 2;
        if (Physics.BoxCast(m_Collider.bounds.center, scale, transform.forward, out hit, transform.rotation, castDistance)){
            if(lookingAtObject != hit.transform.gameObject){ // If changed objects or looked at new object
                if(lookingAtObject != null && lookingAtObject.tag == "Selectable") { // If changed object, deselect previous one
                    lookingAtObject.GetComponent<Renderer>().material.shader = previousShader;
                    previousShader = null;
                }
                
                // And select new one:
                lookingAtObject = hit.transform.gameObject;
                if(lookingAtObject.tag == "Selectable") { //Outline the object:
                    previousShader = lookingAtObject.GetComponent<Renderer>().material.shader;
                    lookingAtObject.GetComponent<Renderer>().material.shader = outlineShader;
                }
            }
        } else if (lookingAtObject != null) {
            if(lookingAtObject.tag == "Selectable") {
                //Deselect object
                lookingAtObject.GetComponent<Renderer>().material.shader = previousShader;
            }
            previousShader = null;
            lookingAtObject = null;
        }

        // Debug:
        if(lookingAtObject != null)
            Debug.Log("Looking at: " + lookingAtObject.name + " " + lookingAtObject.tag);
        else
            Debug.Log("Not Looking at anything");

        if(Input.GetKeyUp(KeyCode.Space)){ // Pick or drop object with spacebar
            if(lookingAtObject != null && lookingAtObject.tag == "Pickable"){  // Pick up object
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

    }
}
