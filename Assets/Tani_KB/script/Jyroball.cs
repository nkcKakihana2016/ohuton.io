using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jyroball : MonoBehaviour
{
    private float speed = 50.0f;

    private Vector3 dir;

    void Start()
    {
     
    }

    void Update()
    {
        dir = Vector3.zero;

        dir.z -= Input.acceleration.x;
        dir.x = Input.acceleration.y;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;

        transform.Rotate(dir * speed);
    }
}
