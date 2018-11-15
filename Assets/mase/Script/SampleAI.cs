using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent( typeof( NavMeshAgent ) )]
public class SampleAI : MonoBehaviour
{
    //public List<GameObject> obj = new List<GameObject>(); 
    //NavMeshAgent agent;
    [SerializeField]
    private Transform[] m_targets = null;
    [SerializeField]
    private float m_destinationThreshold = 0.0f;

    private NavMeshAgent m_navAgent = null;

    private int m_targetIndex = 0;

    private Vector3 CurretTargetPosition
    {
        get
        {
            if (m_targets == null || m_targets.Length <= m_targetIndex)
            {
                return Vector3.zero;
            }

            return m_targets[m_targetIndex].position;
        }
    }
    // Use this for initialization
    void Start ()
    {
        //agent = GetComponent<NavMeshAgent>();
        m_navAgent = GetComponent<NavMeshAgent>();
        m_navAgent.destination = CurretTargetPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //agent.destination = targetObj.transform.position;
        //agent.destination = obj.
        if (m_navAgent.remainingDistance <= m_destinationThreshold)
        {
            m_targetIndex = (m_targetIndex + 1) % m_targets.Length;

            m_navAgent.destination = CurretTargetPosition;
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "HitBox")
    //    {
    //        Debug.Log("当たったんご");
    //    }
    //}
}
