using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jyroball : MonoBehaviour
{
    private float rotSpeed = 10.0f;

    private Vector3 dir;

    void Start()
    {
     
    }

    void Update()
    {
        dir = Vector3.zero;

        dir.y = Input.acceleration.z;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;

        transform.Rotate(dir * rotSpeed);

    }
}
