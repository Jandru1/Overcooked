using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateGUI : MonoBehaviour
{
    public float speed;
    public Vector3 targetPosition;
    void Update()
    {   
        if (Vector3.Distance (transform.position, targetPosition) > 1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
            }
    }

    public void SetPosition(Vector3 target){
        targetPosition = target;
    }

    public float GetTargetX(){
        return targetPosition.x;
    }
}
