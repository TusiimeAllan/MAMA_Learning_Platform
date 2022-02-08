using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayLetter : MonoBehaviour
{
    [SerializeField] bool _uppercase;
    internal void SetLetter(char letter){
        if(_uppercase)
           GetComponent<TMP_Text>().text = letter.ToString().ToUpper();
        else
           GetComponent<TMP_Text>().text = letter.ToString().ToLower();
           

    }
}
