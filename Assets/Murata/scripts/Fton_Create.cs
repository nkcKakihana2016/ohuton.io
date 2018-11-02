using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//布団生成スクリプト
public class Fton_Create : MonoBehaviour {
    //布団生成プレハブ
    public GameObject FtonPrefab;
    public float X_count = 0f;
    public float Z_count = 0f;
	void Start ()
    {
        //X方向に
		for(int X = 0; X <= 17; X++)
        {
            //Z方向に
            for(int Z = 0; Z <= 23; Z++)
            {
                
                //生成
                Instantiate(FtonPrefab,new Vector3(-10f+X+X_count, 0.0f,-17.4f+Z+Z_count),transform.rotation);
                X_count = 1.5f;
                Z_count = 2f;
            }
        }

	}
	
	void Update ()
    {
		
	}
}
