using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongCube : MonoBehaviour
{
    public GameObject youFailed;
    void OnTriggerEnter(){
        Destroy(gameObject);
        StartCoroutine(YouFailed());
    }

    IEnumerator YouFailed(){
        youFailed.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("EvenNumbers");

    }
}
