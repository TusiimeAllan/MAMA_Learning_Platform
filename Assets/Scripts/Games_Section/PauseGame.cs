using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    
    public bool gamePaused = false;

    void update(){

        if(Input.GetButtonDown("Cancel")){

            if(gamePaused == false){
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
            }
            else {
                Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 1;
            }
        }
    }    
    
}
