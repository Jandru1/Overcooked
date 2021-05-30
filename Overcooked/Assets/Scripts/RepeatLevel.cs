using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RepeatLevel : MonoBehaviour
{

    public Button RepeatLevelButton;
    // Start is called before the first frame update
    void Start()
    {
        RepeatLevelButton.onClick.AddListener(Repetir);   
    }

    private void Repetir()
    {
       SceneManager.LoadScene(HoldData.getLevel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
