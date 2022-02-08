using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetName : MonoBehaviour {

    public Text nameGet;

    public static string playerName;

	public void GetPlayerName()
    {
        playerName = nameGet.text.ToUpper().ToString();
    }

}
