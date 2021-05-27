using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiptArray : MonoBehaviour
{
    public RawImage Image;

    public Texture[] Receipts = new Texture[3];

    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Image = GetComponent<RawImage>();
        Image.texture = Receipts[count];
        ++count;
        if (count == 3) count = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
