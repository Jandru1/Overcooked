using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zabuza : MonoBehaviour
{

    public GameObject espada;

    private Vector3 x;
    private Quaternion y;


    // Start is called before the first frame update
    void Start()
    {
        //espada = GetComponent<GameObject>();
        x = espada.transform.position;
        y = espada.transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {

        GameObject NarutoRightHand = GameObject.FindWithTag("RightHand");
        GameObject Naruto = GameObject.FindWithTag("Player");

        Animator animator = Naruto.GetComponent<Animator>();

        if(animator.GetBool("isCutting"))
        {
            // activate the item
            //      espada.setActive(true);

            // replacing the feet by the item
            espada.transform.position = NarutoRightHand.transform.position;
            espada.transform.rotation = Quaternion.Euler(-123, -10, 7);
           // espada.transform.parent = NarutoRightHand.transform.parent;
        }

        else
        {
            espada.transform.position = x;
            espada.transform.rotation = y;
        }
    }
}
