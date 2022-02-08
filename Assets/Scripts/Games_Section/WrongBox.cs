using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class WrongBox : MonoBehaviour
{
    
    public GameObject FadeOut;
    void OnTriggerEnter()
    {
        StartCoroutine(YouFailed());
        
    }

    IEnumerator YouFailed(){

        //youFell.SetActive(true);
        
        yield return new WaitForSeconds(2);
        FadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("QuizScene");
    }
}
