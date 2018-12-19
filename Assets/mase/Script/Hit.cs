using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    GameObject hitobj;
    SampleAI maseAIScript;


	// Use this for initialization
	void Start ()
    {

        hitobj = GameObject.Find("AIMOVE");
        maseAIScript = hitobj.GetComponent<SampleAI>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            maseAIScript.GetComponent<SampleAI>().Playerhit = true;
            Debug.Log("Playerにあったぞー！");
        }
    }

}
