using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HusumaOC : MonoBehaviour
{
    public Animator Husuma;


	// Use this for initialization
	void Start ()
    {
        Husuma.SetBool("open", false);
        Husuma.SetBool("close", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Husuma.SetBool("open", true);
            Husuma.SetBool("close", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Husuma.SetBool("open", false);
            Husuma.SetBool("close", true);        }
    }
}
