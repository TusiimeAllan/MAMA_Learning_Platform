using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class RemainingCounterText : MonoBehaviour
{
    internal void SetRemaining(int remaining){
        GetComponent<TMP_Text>().text = "x" + remaining;
    }
}
