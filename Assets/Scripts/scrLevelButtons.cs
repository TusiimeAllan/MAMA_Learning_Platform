using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrLevelButtons : MonoBehaviour {


    GameObject controller;
    scrController controllerComponent;

    private void Awake()
    {
        controller = GameObject.FindWithTag("GameController");
        controllerComponent = controller.GetComponent<scrController>();

    }

    public void OnLeft()
    {
        if(controllerComponent.currentLevel > 1)
        {

            controllerComponent.ChangeLevel(-1);


        }
    }

    public void OnRight()
    {

        GameObject[] levels = GameObject.FindGameObjectsWithTag("level");

        if (controllerComponent.currentLevel < levels.Length)
        {
            controllerComponent.ChangeLevel(1);

        }
    }

}
