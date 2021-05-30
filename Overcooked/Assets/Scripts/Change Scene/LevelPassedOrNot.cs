using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPassedOrNot : MonoBehaviour
{
    public Text text;
    private int points;
    // Start is called before the first frame update
    void Start()
    {
        points = HoldData.getpoints();
        if (points >=25) text.text = "Level " + HoldData.getLevel() + " Passed!!";
        else text.text = "Try Again:(";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
