using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleAI : MonoBehaviour
{
    public List<GameObject> obj = new List<GameObject>(); 
    NavMeshAgent agent;

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //agent.destination = targetObj.transform.position;
        agent.destination = obj.
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "HitBox")
    //    {
    //        Debug.Log("当たったんご");
    //    }
    //}
}
