using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDarts : MonoBehaviour
{
    /*[SerializeField]
    private Transform barrelTip;

    [SerializeField]
    private GameObject bullet;

    private Vector2 lookDirection;
    private float lookAngle;*/

    public Camera cam;
    public Rigidbody2D player;
    private Vector2 target;


    // Update is called once per frame
    void Update()
    {

        target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector3 difference = target - player.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
        player.rotation = rotationZ;

    }

    
}
