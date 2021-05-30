using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSelector : MonoBehaviour
{
    public int level;
    public float[] rangeTimeBetweenPlates;
    private string[] plates = { "PlatoArrozConAlgas", "RamenDeCarne", "RamenDePescado", "RamenDePollo"};
    private List<string> PossiblePlates;

    private GameObject instantiator;
    void Start()
    {
        PossiblePlates = new List<string>();
        Combiner m_combiner = GetComponent<Combiner>();
        if(level == 1){
            PossiblePlates.Add(plates[0]); 
        }

        instantiator = transform.Find("Instantiator").gameObject;
        StartCoroutine (waiter());
    }
    IEnumerator waiter()
     {
         while(true){
            float wait_time = Random.Range (rangeTimeBetweenPlates[0], rangeTimeBetweenPlates[1]);
            int plate = Random.Range(0, PossiblePlates.Count);
            instantiator.GetComponent<PlateInstantiate>().NewPlate(plate);
            yield return new WaitForSeconds(wait_time);
        }
     }

}
