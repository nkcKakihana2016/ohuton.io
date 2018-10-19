using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRun : MonoBehaviour
{
    public int rotSpeed = 150;

    public bool DamageFlg;

	// Use this for initialization
	void Start ()
    {
        DamageFlg = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
       if(DamageFlg==false)
        {
            Move();
        }
       if(DamageFlg==true)
        {
            transform.Rotate(new Vector3(0, 0, 0));
            DamageFlg = false;
        }

       //ダメージ受けたら（仮）
       if(Input.GetKey(KeyCode.Space))
        {
            DamageFlg = true;
        }
    }

    public void Move()
    {
        transform.Rotate(new Vector3(rotSpeed, 0, 0) * Time.deltaTime);
    }
}
