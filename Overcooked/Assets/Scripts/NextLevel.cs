using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public Button NextLevelButton;
    // Start is called before the first frame update
    void Start()
    {
        NextLevelButton.onClick.AddListener(Repetir);   
    }

    private void Repetir()
    {
       SceneManager.LoadScene(HoldData.getLevel()+1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
