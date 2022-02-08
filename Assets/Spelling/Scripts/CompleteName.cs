using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteName : MonoBehaviour {

    string letters;
    string player;
    public char[] final;

    void Start () {
        player = GetName.playerName;
        final = new char[player.Length];


        for (int i = 0; i < player.Length; i++)
        {
            final[i] = '_';
        }
    }
	
	public string completeIt(char c,int index)
    {
        final[index] = c;
       // Debug.Log(c);
        return new string(final);
    }
}
