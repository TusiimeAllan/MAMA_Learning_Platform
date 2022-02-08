using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class globalScore : MonoBehaviour
{
    public GameObject ScoreBox;
    public static int currentScore;
    public int internalScore;
    void Update()
    {
        internalScore = currentScore;
        ScoreBox.GetComponent<Text>().text = "" + internalScore;
        
    }
}
