using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getScoreFinal : MonoBehaviour {

    public Text texter;

	void Update () {
        texter.text = "Your Score : " + BallController.count;
	}
}
