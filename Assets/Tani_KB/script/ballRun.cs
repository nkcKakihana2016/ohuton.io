using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRun : MonoBehaviour
{
    public int rotSpeed = 150;

	// Use this for initialization
	void Start ()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        //rb.angularVelocity = new Vector3(rotSpeed, 0, 0);
        transform.Rotate(new Vector3(rotSpeed, 0, 0) * Time.deltaTime);
    }
}
