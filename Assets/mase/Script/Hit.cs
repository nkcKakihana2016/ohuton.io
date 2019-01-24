using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject hitobj;
    AIController maseAIScript;


	// Use this for initialization
	void Start ()
    {

        hitobj = GameObject.Find("SampleAI");
        maseAIScript = hitobj.GetComponent<AIController>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            maseAIScript.Playerhit = true;

            //Debug.Log("Playerにあったぞー！");
        }
    }

}
