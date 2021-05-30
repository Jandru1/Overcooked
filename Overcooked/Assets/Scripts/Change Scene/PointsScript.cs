using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour
{

    public float points;
    public int LastLevel;
    public Text text;

    public float puntuacion_final_en_porcentaje;

    private GameObject Estrella1Llena;
    private GameObject Estrella2Llena;
    private GameObject Estrella3Llena;
    private GameObject Estrella1Vacia;
    private GameObject Estrella2Vacia;
    private GameObject Estrella3Vacia;
    // Start is called before the first frame update
    void Start()
    {
        points = HoldData.getpoints();
        text.text = "Has sacado " + points + " puntos!!";
        Estrella1Llena = GameObject.FindGameObjectWithTag("Estrella1Llena");
        Estrella2Llena = GameObject.FindGameObjectWithTag("Estrella2Llena");
        Estrella3Llena = GameObject.FindGameObjectWithTag("Estrella3Llena");
        Estrella1Vacia = GameObject.FindGameObjectWithTag("Estrella1Vacia");
        Estrella2Vacia = GameObject.FindGameObjectWithTag("Estrella2Vacia");
        Estrella3Vacia = GameObject.FindGameObjectWithTag("Estrella3Vacia");
        Estrella1Llena.SetActive(false);
        Estrella2Llena.SetActive(false);
        Estrella3Llena.SetActive(false);
        Estrella1Vacia.SetActive(false);
        Estrella2Vacia.SetActive(false);
        Estrella3Vacia.SetActive(false);

        puntuacion_final_en_porcentaje = points;

        if(puntuacion_final_en_porcentaje < 25)
        {
            Estrella1Vacia.SetActive(true);
            Estrella2Vacia.SetActive(true);
            Estrella3Vacia.SetActive(true);
        }

        else if(puntuacion_final_en_porcentaje >25 && puntuacion_final_en_porcentaje < 50)
        {
            Estrella1Llena.SetActive(true);
            Estrella2Vacia.SetActive(true);
            Estrella3Vacia.SetActive(true);
        }       
        else if (puntuacion_final_en_porcentaje > 50 && puntuacion_final_en_porcentaje < 75)
        {
            Estrella1Llena.SetActive(true);
            Estrella2Llena.SetActive(true);
            Estrella3Vacia.SetActive(true);
        }
        else if (puntuacion_final_en_porcentaje > 75 && puntuacion_final_en_porcentaje <= 100)
        {
            Estrella1Llena.SetActive(true);
            Estrella2Llena.SetActive(true);
            Estrella3Llena.SetActive(true);
        }
    }
}
