using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public GameObject Ball;

    private Vector3 offset;

    void Start()
    {
        Ball = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - Ball.transform.position;
    }

    void Update()
    {
        transform.position = Ball.transform.position + offset;
    }
}
