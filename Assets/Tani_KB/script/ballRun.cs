using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRun : MonoBehaviour
{
    //public int rotSpeed = 150;

    public bool DamageFlg;

	// Use this for initialization
	void Start ()
    {
        DamageFlg = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //ダメージ受けたら（仮）
        if (Input.GetKey(KeyCode.Space))
        {
            DamageFlg = true;
        }

        if (DamageFlg==false)
        {
            //Move();
        }

        if (DamageFlg == true)
        {
            StartCoroutine("GetDamage");
        }
    }
    IEnumerator GetDamage()
    {
        //transform.Rotate(new Vector3(0, 0, 0));
        yield return new WaitForSeconds(3.0f);
        DamageFlg = false;
    }

    public void Move()
    {
        //transform.Rotate(new Vector3(0, rotSpeed, 0) * Time.deltaTime);
    }
}
