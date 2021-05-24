using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopAnimation : MonoBehaviour
{
    Animator anim;

    private RawImage Image;

    void Start()
    {
        anim = GetComponent<Animator>();
        Image = GetComponent<RawImage>();
        anim.SetBool("ReceiptEnters", true);
        anim.SetBool("ReceiptLeaves", false);

        StartCoroutine(Waiter());
    }

    void Update()
    {
    }

    IEnumerator Waiter()
    {
        Debug.Log("eeeeeeeeeeee");
        yield return new WaitForSeconds(5);
        Debug.Log("AAAAAAAAAAAAAAAA");
        anim.SetBool("ReceiptEnters", false);
        anim.SetBool("ReceiptLeaves", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Image"))
        {
            anim.enabled = false;
        }
    }
}
