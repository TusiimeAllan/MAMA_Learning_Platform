using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBackground : MonoBehaviour
{
   public float RotateSpeed = 1;

    void Update()
    {
        this.transform.Rotate(0, 0, RotateSpeed, Space.World);
    }
}
