using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public static ScoreController instance;
    public int counter = 0;

    public Text scoreCount;
    // Update is called once per frame
    void Update () {
        scoreCount.text = "Score : " + counter.ToString();
	}
}
