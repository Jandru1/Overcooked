using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRamenObject : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public bool isInRange;
    public KeyCode interactKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                StartCoroutine(Peracagon());
                Replace(obj1, obj2);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            isInRange = false;
            Debug.Log("Player now NOT in range");
        }
    }
    void Replace(GameObject obj1, GameObject obj2)
    {
        Instantiate(obj2, obj1.transform.position, Quaternion.identity);
        Destroy(obj1);
    }

    IEnumerator Peracagon()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Wait is over");
    }
}
