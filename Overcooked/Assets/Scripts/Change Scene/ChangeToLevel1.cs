using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeToLevel1 : MonoBehaviour
{
    public Button ChangeLevelButton;
    public string leveltoLoad;
    // Start is called before the first frame update
    void Start()
    {
        ChangeLevelButton.onClick.AddListener(Repetir);
    }

    private void Repetir()
    {
        SceneManager.LoadScene(leveltoLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
