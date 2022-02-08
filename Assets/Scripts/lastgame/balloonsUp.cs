using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonsUp : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    public int balloonImageIndex;
    spawner spawn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, speed, 0);
        Destroy(this.gameObject,10);

        spawn = GameObject.Find("Canvas").GetComponent<spawner>();
        balloonImageIndex = spawn.balloonIndex;
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("ballon")) {
            GameObject.Find("BallonBombvoice").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
    }
}
