using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class PlaceTracker : MonoBehaviour
{
    public Room sampleRoom;
    public GameObject canvas;
    [HideInInspector]public Room currentRoom=null;

    Vector3 defaultPivot=new Vector3(0,-0.5f,0);
    
    public void SetRoom(){
        if(!currentRoom) {
            currentRoom=Instantiate(sampleRoom);
        }
    
        currentRoom.transform.rotation=Quaternion.LookRotation(currentRoom.playerPoint.position-currentRoom.targetPoint.position);
        currentRoom.transform.position=Camera.main.transform.position-currentRoom.playerPoint.position+defaultPivot;
        canvas.SetActive(false);
    }
}
