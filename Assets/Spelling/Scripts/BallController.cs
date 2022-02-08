using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
    public float rotationSpeed = 100f;

    private Rigidbody rb;

    private bool isFalling = false;

    public float damp = 0.7f;

    public static int count;
    public Text countText;
    public Text NameView;


    public string playerName = "A";

    private static  GameObject go;
    public float movementSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

    }

    


    // Update is called once per frame
    void Update () {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown("space") && isFalling == false)
        {
            Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);
            rb.AddForce(jump);
        }
        isFalling = true;

    }

    

    void OnCollisionStay()
    {
        isFalling = false;
    }

    void OnCollisionEnter()
    {
        rb.velocity *= damp;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }

}
