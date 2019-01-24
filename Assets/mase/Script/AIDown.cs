using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDown : MonoBehaviour
{
    GameObject Aiobj;
    AIController aIController;


	// Use this for initialization
	void Start ()
    {

        Aiobj = GameObject.Find("SampleAI");
        aIController = Aiobj.GetComponent<AIController>();

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="player")
        {
            Debug.Log("ヒット");
            aIController.enemy = true;

        }
        if (other.gameObject.tag == "ai")
        {
            aIController.enemy = true;
        }
    }
}
