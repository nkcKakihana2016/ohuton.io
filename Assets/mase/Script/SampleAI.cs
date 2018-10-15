using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleAI : MonoBehaviour
{
    public GameObject[] targetObj;
    NavMeshAgent agent;

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
     //   agent.SetDestination(target.position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HitBox")
        {
            Debug.Log("当たったんご");
        }
    }
}
