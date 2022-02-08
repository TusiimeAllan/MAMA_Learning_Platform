using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject ScreenToShow;

    public GameObject ScreenToHide1;
    public GameObject ScreenToHide2;
    public GameObject ScreenToHide3;
    
    [Space]
    public GameObject MenuBtnToShow;

    public GameObject MenuBtnToHide1;
    public GameObject MenuBtnToHide2;
    public GameObject MenuBtnToHide3;

    void Update(){
        if(gameObject.activeSelf){
            //For Screens
            ScreenToShow.SetActive(true);

            ScreenToHide1.SetActive(false);
            ScreenToHide2.SetActive(false);
            ScreenToHide3.SetActive(false);

            //For Buttons
            MenuBtnToShow.SetActive(true);

            MenuBtnToHide1.SetActive(false);
            MenuBtnToHide2.SetActive(false);
            MenuBtnToHide3.SetActive(false);
        }
    
    }
}
