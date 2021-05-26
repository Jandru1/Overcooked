using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopAnimation : MonoBehaviour
{
    Animator anim;

    GameObject o;

    private int i = 0;

    private RawImage Image;

    GameObject go;

    void Start()
    {
    //   anim = o.transform.parent.GetComponent<Animator>();

        anim = GetComponent<Animator>();
        Image = GetComponent<RawImage>();
        go = GetComponent<GameObject>();

        anim.SetBool("ReceiptLeaves", false);
        anim.SetBool("ReceiptEnters", false);

        StartCoroutine(Waiter());
    }

    void Update()
    {
    }

    IEnumerator Waiter()
    {
        if (!anim.GetBool("ReceiptEnters") & !anim.GetBool("ReceiptLeaves"))
        {
            anim.SetBool("ReceiptEnters", true);
            anim.SetBool("ReceiptLeaves", false);
            ++i;

        }
        Debug.Log("i = "+ i);
        if (anim.GetBool("ReceiptEnters"))//Condition of ReceiptDone
        {
            yield return new WaitForSeconds(5);
            anim.SetBool("ReceiptEnters", false);
            anim.SetBool("ReceiptLeaves", true);
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Image"))
        {
            Debug.Log("ENTRAMOS EN COLLIDER");
            anim.speed = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Image"))
        {
          //  anim.enabled = true;
        }
    }
    
}
