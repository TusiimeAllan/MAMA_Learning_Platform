using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    public GameObject levelMusic;
    public AudioSource levelComplete;
    public GameObject levelTimer;
    public GameObject timeLeft;
    public GameObject theScore;
    public GameObject totalScore;
    public GameObject levelBlocker;
    public int timeCalc;
    public int scoreCalc;
    public int totalScored;
    void OnTriggerEnter(){
        //levelBlocker.SetActive(true);
        //levelBlocker.transform.parent = null;
        timeCalc = globalTimer.extendScore*100;
        timeLeft.GetComponent<Text>().text = "Time Left:" + timeCalc + " x 100";
        theScore.GetComponent<Text>().text = "Score: " + globalScore.currentScore;
        totalScored = globalScore.currentScore + timeCalc;
        totalScore.GetComponent<Text>().text = "Total score: " + totalScored;

        levelMusic.SetActive(false);
        levelTimer.SetActive(false);
        levelComplete.Play();
        StartCoroutine(CalculateScore());
    }
    IEnumerator CalculateScore()
    {
        timeLeft.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        theScore.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        totalScore.SetActive(true);
        yield return new WaitForSeconds(0.25f);



    }
}
