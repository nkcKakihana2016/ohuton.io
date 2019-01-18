using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointhit : MonoBehaviour
{



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "point")
        {
            Destroy(other.gameObject);
            Debug.Log("お前消すんご");
        }
    }

}
