using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public void ExitGame () {
        Debug.Log("Exiting");
        Application.Quit();
	}


    public void StartGame(string name)
    {

        Application.LoadLevel(name);

    }

    
}
