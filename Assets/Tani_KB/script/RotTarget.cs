using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotTarget : MonoBehaviour
{

    Transform Target;

    float angle = 10.0f;

    float rot = 10.0f;

    // Use this for initialization
    void Start ()
    {
        Target = GameObject.Find("PlayerObj").GetComponent<Transform>();//オブジェクトを探す
    }
	
	// Update is called once per frame
	void Update ()
    {
        rot = Input.GetAxis("Horizontal");
        transform.RotateAround(Target.position, Vector3.up, angle * rot);
    }
}
