using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadBar : MonoBehaviour
{
    private GameObject interactable;
    private Slider slider;
    private float interactionStepTime;
    private IEnumerator coroutine;
    void Start()
    {
        interactable = transform.parent.parent.gameObject;
        interactionStepTime = interactable.GetComponent<Interactable>().interactionTimeNeeded / 100;
        slider = GetComponent<Slider>();
        gameObject.SetActive(false);
    }

    public void StartInteraction(){
        coroutine = Interaction();
        StartCoroutine(coroutine);
    }

    IEnumerator Interaction()
    {
        while(interactable.GetComponent<Interactable>().interacting){
            slider.value += .01f;
            yield return new WaitForSeconds(interactionStepTime);
        }
        StopCoroutine(coroutine);
        gameObject.SetActive(false);
    }
}
