using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;
    public float bulletforce = 20f;
    bool b = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && b == true)
        {
            shoot();
        }
    }

    void shoot()
    {
        GameObject bull =  Instantiate(bullet,firepoint.position , firepoint.rotation);
        Rigidbody2D rb = bull.GetComponent<Rigidbody2D>();
        //rb.AddForce(firepoint.up * bulletforce);
        rb.velocity = firepoint.up * -bulletforce;

    }

    public void StartShoot(bool x)
    {
        b = x;
    }
}
