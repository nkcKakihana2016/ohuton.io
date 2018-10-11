using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HusumaOC : MonoBehaviour
{
    public Animator Husuma;
    public float SceneTimer = 3.0f;

	// Use this for initialization
	void Start ()
    {
        Husuma.SetBool("open", false);
        Husuma.SetBool("close", false);
        Husuma.SetBool("normal", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetKey(KeyCode.A))
        //{
        //    Husuma.SetBool("open", true);
        //    Husuma.SetBool("close", false);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    Husuma.SetBool("open", false);
        //    Husuma.SetBool("close", true);
        //    Husuma.SetBool("normal", false);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    Husuma.SetBool("close", false);
        //    Husuma.SetBool("normal", true);
        //}
    }

    public void NormalOpen()
    {
        Husuma.SetBool("close", false);
        Husuma.SetBool("normal", true);
    }

    public void ResultOpen()
    {
        Husuma.SetBool("open", true);
        Husuma.SetBool("close", false);
    }

    public void CloseHusuma()
    {
        Husuma.SetBool("open", false);
        Husuma.SetBool("close", true);
        Husuma.SetBool("normal", false);
    }
}
