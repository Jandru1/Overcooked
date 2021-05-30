using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string leveltoLoad;
    public float timer = 120f;
    private Text textDisplay;
    // Start is called before the first frame update
    void Start()
    {
        textDisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        string lastText = textDisplay.text;
        int minutes = (int) timer / 60;
        int seconds = (int) timer % 60;
        string formatSeconds = seconds < 10 ? "0" + seconds : "" + seconds;
        textDisplay.text = "0" + minutes + ":" + formatSeconds;
        if(timer <= 11){
            GetComponent<Text>().color = Color.red;
            if(lastText != textDisplay.text)
                GetComponent<AudioSource>().Play();
        }
        if(timer <=0)
        {
            int a = SceneManager.GetActiveScene().buildIndex;
            HoldData.setpoints(100); //puntos totales
            HoldData.setLastLevel(a); // Ultimo Nivel
            SceneManager.LoadScene(leveltoLoad);
        }
    }
}
