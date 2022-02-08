using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuFunction : MonoBehaviour
{
    public AudioSource buttonPress;
    

    public void PlayGame(){

        buttonPress.Play();
        //takes you to desired level
        //RedirectToLevel.redirectToLevel = 1;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void PlayCreds(){
        buttonPress.Play();
        SceneManager.LoadScene("Credits");
        
        
    }

    public void PlayEvenNumberGame(){
    
        SceneManager.LoadScene("EvenNumbers");
    }

    public void Goback(){
        
        SceneManager.LoadScene("Menu");
    }
}
