using UnityEngine;

abstract public class Interactable : MonoBehaviour
{
    public float interactionTimeNeeded;
    public float timer;
    
    public bool interacting;

    private GameObject stand;
    public void StartInteraction(GameObject standTrigger)
    {
        timer = 0;
        interacting = true;
        stand = standTrigger;
    }

    
    public void StopInteraction()
    {
        interacting = false;
        stand.GetComponent<DefaultStandBehaviour>().finishedInteracting();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(interacting){
            timer += Time.deltaTime;
            Debug.Log(timer);
            if(timer >= interactionTimeNeeded) {
                StopInteraction();
            }
        }
    }
}
