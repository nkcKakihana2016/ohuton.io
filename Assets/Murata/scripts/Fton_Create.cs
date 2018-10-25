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
                Instantiate(FtonPrefab,new Vector3(-9.8f+X, 0.0f,-17.4f+Z),transform.rotation);
            }
        }

	}
	
	void Update ()
    {
		
	}
}
