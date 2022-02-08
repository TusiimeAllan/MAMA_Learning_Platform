using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBall : MonoBehaviour {

    int maxFall = -10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= maxFall)
        {
            transform.position = new Vector3(-7.5f,1.3f,-0.03f);

        }
	}
}
