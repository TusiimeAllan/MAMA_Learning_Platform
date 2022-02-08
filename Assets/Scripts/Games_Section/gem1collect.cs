using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gem1collect : MonoBehaviour
{
   public GameObject ScoreBox;
   public AudioSource collectSound;

   void OnTriggerEnter(){
       globalScore.currentScore += 20;
       collectSound.Play();
       Destroy(gameObject);
   }
    
}
