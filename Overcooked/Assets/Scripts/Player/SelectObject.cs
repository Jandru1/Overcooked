using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    public float castDistance = 1.2f;
    private Collider m_Collider;
    private GameObject selectedObject;

    void Start(){
        m_Collider = GetComponent<Collider>();
        selectedObject = null;
    }
    void Update()
    {
        RaycastHit hit;
        Vector3 scale = transform.localScale;
        scale.y *= 2;
        if (Physics.BoxCast(m_Collider.bounds.center, scale, transform.forward, out hit, transform.rotation, castDistance)){
            Debug.Log("Looking at: " + hit.transform.gameObject.name);
            if(hit.transform.tag == "Selectable" && Input.GetMouseButtonDown(0)){
                selectedObject = hit.transform.gameObject;
                selectedObject.GetComponent<PickUpObject>().Select();
            }
        }
        if (selectedObject != null && Input.GetMouseButtonUp(0))
            selectedObject.GetComponent<PickUpObject>().Unselect();

    }
}
