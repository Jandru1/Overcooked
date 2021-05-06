using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNaruto : MonoBehaviour
{

    public float speed = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(+speed * Time.deltaTime, 0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(0.0f, -speed * Time.deltaTime, 0.0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(0.0f, +speed * Time.deltaTime, 0.0f);
        }
    }
}
