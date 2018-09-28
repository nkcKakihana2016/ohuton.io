using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballRun : MonoBehaviour
{
    private float speed = 10.0f;

    private Vector3 dir;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        dir = Vector3.zero;

        dir.x = Input.acceleration.x;
        dir.z = Input.acceleration.y;

        if(dir.sqrMagnitude>1)
            dir.Normalize();

        dir *= Time.deltaTime;

        transform.Translate(dir * speed);

    }
}
