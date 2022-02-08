using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globalTimer : MonoBehaviour
{


    public GameObject timeDisplay1;
    public bool isTakingTime = false;
    public int theSeconds = 30;
    public static int extendScore;
    public GameObject levelBlocker;
    // Start is called before the first frame update
    void Update(){
        extendScore = theSeconds;
        if(isTakingTime == false){
            StartCoroutine(SubtractSecond());
        }
    }
    
    
    
    IEnumerator SubtractSecond(){
        isTakingTime = true; 
        if(theSeconds > 0){
            theSeconds -= 1;
            timeDisplay1.GetComponent<Text>().text = "" + theSeconds;
            yield return new WaitForSeconds(1);
            isTakingTime = false;
        }
        else{
            levelBlocker.SetActive(true);
            levelBlocker.transform.parent = null;

        }    


    }



}
