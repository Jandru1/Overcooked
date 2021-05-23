using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour
{
    Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && anim.isPlaying)
        {
            anim.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Image"))
        {
            Debug.Log("AAAAAAAAAAAAAAAA");
            anim.Stop();
        }
    }
}
