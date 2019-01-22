using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointhit : MonoBehaviour
{

    public GameObject AImove;
    AIController aIController;

    public void Start()
    {
        AImove = GameObject.Find("AIMOVE");
        aIController = AImove.GetComponent<AIController>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "point")
        {
            Destroy(other.gameObject);
            Debug.Log("お前消すんご");

            aIController.futongetCount += 1;
            Debug.Log(aIController.futongetCount);
        }
    }

}
