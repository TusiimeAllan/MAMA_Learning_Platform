using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckIfActive : MonoBehaviour
{
    public GameObject ActiveTriangle;
    public GameObject ActiveCircle;
    public GameObject ActiveRectangle;
    public GameObject ActiveSquare;
    public GameObject CorrectPanel;
    public GameObject WrongPanel;

    public void CheckingForTriangle(){
        if(ActiveTriangle.activeSelf){
            CorrectPanel.SetActive(true);
        }
        else{
            WrongPanel.SetActive(true);
        }
    }
    public void CheckingForCircle(){
        if(ActiveCircle.activeSelf){
            CorrectPanel.SetActive(true);
        }
        else{
            WrongPanel.SetActive(true);
        }
    }
    public void CheckingForRectangle(){
        if(ActiveRectangle.activeSelf){
            CorrectPanel.SetActive(true);
        }
        else{
            WrongPanel.SetActive(true);
        }
    }
    public void CheckingForSquare(){
        if(ActiveSquare.activeSelf){
            CorrectPanel.SetActive(true);
        }
        else{
            WrongPanel.SetActive(true);
        }
    }
    

    
}
