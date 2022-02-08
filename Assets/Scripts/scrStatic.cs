using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class scrStatic : MonoBehaviour {

    private void Awake()
    {
        gameObject.tag = "static";
    }


}
