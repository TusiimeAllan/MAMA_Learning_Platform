using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrBalloon : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * Time.deltaTime * 10);
    }
}
