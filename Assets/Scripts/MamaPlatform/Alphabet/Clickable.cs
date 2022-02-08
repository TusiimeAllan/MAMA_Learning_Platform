using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerClickHandler
{

    char _randomLetter;

    public void OnPointerClick(PointerEventData eventData){
        Debug.Log($"Clicked on letter {_randomLetter}");
        if (_randomLetter == GameController._letter){
          GetComponent<TMP_Text>().color = Color.green;
          enabled = false;
          GameController.HandleCorrectLetterClick();
          

        }
    }

    //private void Update(){

    //}
    // private void OnEnable(){
        
    //     System.Random random = new System.Random();
    //     random lowercase letter
    //     int a = Random.Range(0, 26);
    //     _randomLetter = (char)('a' + a);

    //     if (Random.Range(0, 100)>50){
    //        GetComponent<TMP_Text>().text = _randomLetter.ToString();
    //     }
    //     else{
    //         GetComponent<TMP_Text>().text = _randomLetter.ToString().ToUpper();
    //     }
    // }

        internal void SetLetter(char letter){
          enabled = true;
          GetComponent<TMP_Text>().color = Color.white;
            _randomLetter = letter;
            if (Random.Range(0, 100)>50){
           GetComponent<TMP_Text>().text = _randomLetter.ToString();
        }
        else{
            GetComponent<TMP_Text>().text = _randomLetter.ToString().ToUpper();
        }
        }
    
}


