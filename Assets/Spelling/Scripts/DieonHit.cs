using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieonHit : MonoBehaviour
{
    public string str;
    public TextMesh textMesh;
    public string nameOfPlayer;
    string correctWord;
    public Text gotWord;
    

    

    public Text counterText;

   
    int flag;
    int checker;


    CompleteName cn;

    void Start()
    {
        str = textMesh.text;
        nameOfPlayer = GetName.playerName;
        //counter = BallController.count;
        flag = 0;

        cn = GameObject.FindGameObjectWithTag("Viewer").GetComponent<CompleteName>();
        //correctWord = "";        
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            int res = Correction();
            if(res == 1)
            {
                BallController.count = BallController.count + 5;
                SetCountText();
                //CorrectWord();
                gotWord.text = correctWord;
                if(correctWord == nameOfPlayer)
                {
                    Application.LoadLevel("GameOverLevel");
                }
            }
            else
            {
                BallController.count = BallController.count - 5;
                SetCountText();
            }
            Destroy(this.gameObject);
            
        }
    }

    public int Correction()
    {
        flag = 0;
        for(int i = 0; i < nameOfPlayer.Length; i++)
        {
            if(nameOfPlayer[i] == str[0])
            {
                //final[i] = str[0];
                flag = 1;
                correctWord = cn.completeIt(nameOfPlayer[i],i);
                Debug.Log(correctWord);
                checker++;
            }
        }
        return flag; 
    }

   /* public void CorrectWord()
    {
        //correctWord = "";
        for (int i = 0; i < nameOfPlayer.Length; i++)
        {
            correctWord += final[i];
        }
        Debug.Log(correctWord + "this is it");
    }*/

    void SetCountText()
    {
        counterText.text = "Score: " + BallController.count.ToString();
    }
}
      
         


