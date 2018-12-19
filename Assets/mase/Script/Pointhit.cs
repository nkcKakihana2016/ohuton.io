using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointhit : MonoBehaviour
{

    GameObject AImove;
    SampleAI AIController;

    public void Start()
    {
        AImove = GameObject.Find("AIMOVE");
        AIController = AImove.GetComponent<SampleAI>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "point")
        {
            Destroy(other.gameObject);
            Debug.Log("お前消すんご");

            AIController.futongetCount += 1;
            Debug.Log(AIController.futongetCount);
        }
    }

}
