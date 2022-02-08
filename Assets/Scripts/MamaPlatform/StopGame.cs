using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StopGame : MonoBehaviour
{
    public GameObject levelAudio;
    public AudioSource levelComplete;
    public GameObject levelTimer;
    public GameObject timeLeft;
    public GameObject theScore;
    public GameObject totalScore;
    //public GameObject levelBlocker;
    public int timeCalc;
    public int scoreCalc;
    public int totalScored;
    void OnTriggerEnter(){
        //levelBlocker.SetActive(true);
        //levelBlocker.transform.parent = null;
        timeCalc = globalTimer.extendScore;
        timeLeft.GetComponent<Text>().text = "Time Left:" + globalTimer.extendScore;
        theScore.GetComponent<Text>().text = "Score: " + globalScore.currentScore;
        totalScored = globalScore.currentScore + timeCalc;
        totalScore.GetComponent<Text>().text = "Total score: " + totalScored;

        levelAudio.SetActive(false);
        levelTimer.SetActive(false);
        levelComplete.Play();
        StartCoroutine(CalculateScore());
    }
    IEnumerator CalculateScore()
    {
        timeLeft.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        theScore.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        totalScore.SetActive(true);
        yield return new WaitForSeconds(3.5f);



    }
}
