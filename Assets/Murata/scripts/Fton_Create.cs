using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fton_Create : MonoBehaviour {

    public GameObject FtonPrefab;
	void Start ()
    {
		for(int X = 0; X <= 17; X++)
        {
            for(int Z = 0; Z <= 23; Z++)
            {
                Instantiate(FtonPrefab,new Vector3(-11.5f+X, -1.8f,-17.2f+Z),transform.rotation);
            }
        }

	}
	
	void Update ()
    {
		
	}
}
