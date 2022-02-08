using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetName : MonoBehaviour {

    public Text nameSet;

	void Start () {
        nameSet.text = GetName.playerName;
        //nameSet.text = "SANDZ";
    }
	
}
