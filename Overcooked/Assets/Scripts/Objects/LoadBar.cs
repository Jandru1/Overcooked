using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadBar : MonoBehaviour
{
    public Slider BarraDeCarga;

    private int maxTime = 151;
    private int currentTime;

    public static LoadBar instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        BarraDeCarga.gameObject.SetActive(false);
        currentTime = 0;
        BarraDeCarga.maxValue = maxTime;
        BarraDeCarga.value = maxTime;
    }

    public void UserBar(int amount)
    {
        BarraDeCarga.gameObject.SetActive(true);

        if (currentTime == maxTime)
        {
            Debug.Log("yata");
            BarraDeCarga.gameObject.SetActive(false);
        }

        else
        {
            ++currentTime;
            BarraDeCarga.value = currentTime;

        }
        /*

        if (currentTime - amount >= 0)
        {
            currentTime -= amount;
            BarraDeCarga.value = currentTime;
        }
        else
        {
            Debug.Log("not anought stamina");
        }
        */
    }
}
