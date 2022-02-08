using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGripper : MonoBehaviour
{
    
    public GameObject theLedge;
    public GameObject thePlayer;

    void OnTriggerEnter(){
        thePlayer.transform.parent = theLedge.transform;
    }

    void OnTriggerExit(){
        thePlayer.transform.parent = null;
    }
}
