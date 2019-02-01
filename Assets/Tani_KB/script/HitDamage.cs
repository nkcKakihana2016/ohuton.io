using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamage : MonoBehaviour
{
    GameObject parent;
    Jyroball jyroball;

	// Use this for initialization
	void Start ()
    {
        parent = GameObject.Find("PlayerObj");
        jyroball = parent.GetComponent<Jyroball>();
	}

    public void OnTriggerEnter(Collider other)
    {
        //頭のダメージ処理(当たり判定)
        if (other.gameObject.tag == "player")
        {
            Debug.Log("当たった");
            jyroball.TouchDamage();
        }

        if (other.gameObject.tag == "ai")
        {
            Debug.Log("当たった敵");
            jyroball.TouchDamage();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
