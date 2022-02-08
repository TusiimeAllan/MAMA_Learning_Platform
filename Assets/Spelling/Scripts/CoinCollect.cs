using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour {

    public Transform destroyEffect;
    public Transform effect;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            effect = Instantiate(effect, transform.position, transform.rotation);
            Destroy(effect.gameObject, 3);      
            Destroy(gameObject);           
        }
    }

   
}
