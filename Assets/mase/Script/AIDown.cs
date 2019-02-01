using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDown : MonoBehaviour
{
    GameObject Aiobj;
    AIController aIController;
    GameObject hitobj;
    Pointhit pointhit;


	// Use this for initialization
	void Start ()
    {

        Aiobj = GameObject.Find("AImove");
        aIController = Aiobj.GetComponent<AIController>();
        hitobj = GameObject.Find("AI");
        pointhit = hitobj.GetComponent<Pointhit>();


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
