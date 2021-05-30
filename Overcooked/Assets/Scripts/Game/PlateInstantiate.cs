using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateInstantiate : MonoBehaviour
{
    public GameObject PlatoArrozConAlgasGUI; 
    public GameObject RamenDeCarneGUI; 
    public GameObject RamenDePescadoGUI; 
    public GameObject RamenDePolloGUI; 
    
    private List<GameObject> Prefabs;
    private List<GameObject> PlatesRequested;

    public int totalPlates;
    public int platesDone;

    public float targetPosX;
    private Vector3 startPos;
    void Start(){
        Prefabs = new List<GameObject>();
        Prefabs.Add( PlatoArrozConAlgasGUI ); 
        Prefabs.Add( RamenDeCarneGUI ); 
        Prefabs.Add( RamenDePescadoGUI ); 
        Prefabs.Add( RamenDePolloGUI ); 
        PlatesRequested = new List<GameObject>();
        totalPlates = 0;
        platesDone = 0;
        targetPosX = 100f;
        startPos = new Vector3(457f,162f,0);
    }
    public void NewPlate(int plateID){
        ++totalPlates;
        HoldData.setpoints(((float) platesDone/(float)totalPlates) * 100);
        GameObject plate = Instantiate(Prefabs[plateID]);
        plate.transform.position = startPos;
        plate.transform.SetParent(transform.parent, false);
        plate.GetComponent<PlateGUI>().SetPosition(new Vector3(targetPosX,plate.transform.position.y,plate.transform.position.z));
        PlatesRequested.Add(plate);
        targetPosX += 200f;
    }

    public bool DonePlate(string plateID){
        for(int i = 0; i < PlatesRequested.Count; ++i){
            if(PlatesRequested[i].GetComponent<Identifiers>().id == plateID){
                GameObject GUIelement = PlatesRequested[i];
                targetPosX = GUIelement.GetComponent<PlateGUI>().GetTargetX();
                PlatesRequested.RemoveAt(i);
                Destroy(GUIelement);
                GetComponent<AudioSource>().Play();
                ++platesDone;
                HoldData.setpoints(((float)platesDone/(float)totalPlates) * 100);
                for(int j = i; j < PlatesRequested.Count; ++j){
                    GameObject plate = PlatesRequested[j];
                    plate.GetComponent<PlateGUI>().SetPosition(new Vector3(targetPosX, plate.transform.position.y,plate.transform.position.z));
                    targetPosX += 200f; 
                }
                return true;
            }
        }
        return false;
    }

}
