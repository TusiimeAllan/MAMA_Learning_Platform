using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class greenGem : MonoBehaviour
{
   public GameObject ScoreBox;
   public AudioSource collectSound;

   void OnTriggerEnter(){
       globalScore.currentScore += 500;
       collectSound.Play();
       Destroy(gameObject);
   }
    
}
