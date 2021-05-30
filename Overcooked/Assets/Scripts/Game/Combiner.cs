using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combiner : MonoBehaviour
{
    public GameObject Plate; 
    public GameObject Olla; 
    public GameObject OllaConArroz; 
    public GameObject OllaConFideos; 
    public GameObject AlgaCortada; 
    public GameObject AlgaCruda; 
    public GameObject ArrozConAlgas; 
    public GameObject ArrozCrudo; 
    public GameObject ArrozHervido; 
    public GameObject CarneCortada; 
    public GameObject CarneSinCortar; 
    public GameObject Espaguettis; 
    public GameObject Fideos; 
    public GameObject PescadoCrudo; 
    public GameObject PescadoHecho; 
    public GameObject PolloCocinao; 
    public GameObject PolloVivo; 
    public GameObject PlatoAlgaCortada; 
    public GameObject PlatoArrozConAlgas; 
    public GameObject PlatoSoloArroz; 
    public GameObject RamenDeCarne; 
    public GameObject RamenDePescado; 
    public GameObject RamenDePollo; 
    public GameObject RamenEspaguettis; 
    public GameObject RamenSoloCarne; 
    public GameObject RamenSoloPescado; 
    public GameObject RamenSoloPollo; 
    public GameObject RamenVacio; 
   private string[] array = { "Plate", "Olla", "OllaConArroz", "OllaConFideos", "AlgaCortada", "AlgaCruda", "ArrozConAlgas", "ArrozCrudo", "ArrozHervido", "CarneCortada", "CarneSinCortar", "Espaguettis", "Fideos", "PescadoCrudo", "PescadoHecho", "PolloCocinao", "PolloVivo", "PlatoAlgaCortada", "PlatoArrozConAlgas", "PlatoSoloArroz", "RamenDeCarne", "RamenDePescado", "RamenDePollo", "RamenEspaguettis", "RamenSoloCarne", "RamenSoloPescado", "RamenSoloPollo", "RamenVacio", "Cortar"};
   private string[] cuttableItems = { "AlgaCruda", "CarneSinCortar"};
   public List<string> idList;
   private List<GameObject> Prefabs;
   private string[,] COMBINATIONS = new string[,] {{"-1", "-1", "-1", "-1", "PlatoAlgaCortada", "-1", "PlatoArrozConAlgas", "-1", "PlatoSoloArroz", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "OllaConArroz", "-1", "-1", "-1", "OllaConFideos", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"PlatoAlgaCortada", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "ArrozConAlgas", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "PlatoArrozConAlgas", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "AlgaCortada"},
{"PlatoArrozConAlgas", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"PlatoSoloArroz", "-1", "-1", "-1", "ArrozConAlgas", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "PlatoArrozConAlgas", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "RamenDeCarne", "-1", "-1", "-1", "RamenSoloCarne", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "CarneCortada"},
{"-1", "-1", "-1", "Olla", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "RamenDeCarne", "RamenDePescado", "RamenDePollo", "RamenEspaguettis", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "RamenDePescado", "-1", "-1", "-1", "RamenSoloPescado", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "RamenDePollo", "-1", "-1", "-1", "RamenSoloPollo", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "PlatoArrozConAlgas", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "PlatoArrozConAlgas", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "RamenDeCarne", "-1", "-1", "-1", "-1", "RamenDePescado", "RamenDePollo", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "RamenDeCarne", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "RamenDePescado", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "RamenDePollo", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "RamenSoloCarne", "-1", "-1", "RamenEspaguettis", "-1", "RamenSoloPescado", "RamenSoloPollo", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"},
{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1"}};
   void Start () {
        idList = new List<string>(array);

        Prefabs = new List<GameObject>();
        Prefabs.Add( Plate ); 
        Prefabs.Add( Olla ); 
        Prefabs.Add( OllaConArroz ); 
        Prefabs.Add( OllaConFideos ); 
        Prefabs.Add( AlgaCortada ); 
        Prefabs.Add( AlgaCruda ); 
        Prefabs.Add( ArrozConAlgas ); 
        Prefabs.Add( ArrozCrudo ); 
        Prefabs.Add( ArrozHervido ); 
        Prefabs.Add( CarneCortada ); 
        Prefabs.Add( CarneSinCortar ); 
        Prefabs.Add( Espaguettis ); 
        Prefabs.Add( Fideos ); 
        Prefabs.Add( PescadoCrudo ); 
        Prefabs.Add( PescadoHecho ); 
        Prefabs.Add( PolloCocinao ); 
        Prefabs.Add( PolloVivo ); 
        Prefabs.Add( PlatoAlgaCortada ); 
        Prefabs.Add( PlatoArrozConAlgas ); 
        Prefabs.Add( PlatoSoloArroz ); 
        Prefabs.Add( RamenDeCarne ); 
        Prefabs.Add( RamenDePescado ); 
        Prefabs.Add( RamenDePollo ); 
        Prefabs.Add( RamenEspaguettis ); 
        Prefabs.Add( RamenSoloCarne ); 
        Prefabs.Add( RamenSoloPescado ); 
        Prefabs.Add( RamenSoloPollo ); 
        Prefabs.Add( RamenVacio ); 
   }
   private int getIDNumber(string id){
       for (int i = 0; i < idList.Count; ++i){
           if(idList[i] == id) return i;
       }
       return -1;
   }
    public GameObject Combine(GameObject obj1, GameObject obj2){
        int id1 = getIDNumber(obj1.GetComponent<Identifiers>().id);
        int id2 = getIDNumber(obj2.GetComponent<Identifiers>().id);
        string idCombination = COMBINATIONS[id1, id2];
        if(idCombination != "-1"){
            Transform transformObj1 = obj1.transform;
            Destroy(obj1);
            Destroy(obj2);
            GameObject newObject = Instantiate(Prefabs[getIDNumber(idCombination)]);
            newObject.transform.position = transformObj1.position;
            newObject.transform.rotation = transformObj1.rotation;
            return newObject;
        }
        return null;
    }

    public bool IsCuttable(string id){
        for (int i = 0; i < cuttableItems.Length; ++i){
           if(cuttableItems[i] == id) return true;
        }
        return false;
    }

    public GameObject Cortar(GameObject obj){
        int id1 = getIDNumber(obj.GetComponent<Identifiers>().id);
        string idCombination = COMBINATIONS[id1, getIDNumber("Cortar")];
        if(idCombination != "-1"){
            Transform transformObj = obj.transform;
            Destroy(obj);
            GameObject newObject = Instantiate(Prefabs[getIDNumber(idCombination)]);
            newObject.transform.position = transformObj.position;
            newObject.transform.rotation = transformObj.rotation;
            return newObject;
        }
        return null;
    }
}
