using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 壁スクリプト
/// </summary>
public class Wall_Collider : MonoBehaviour
{

   //  GameObject PlayerObject;


    [SerializeField]
    //座標
    Vector3 POS;
    void Start()
    {
        //   PlayerObject = GameObject.Find("human");
    }


    void Update()
    {
        
    }
    //壁に衝突したら
    public void OnCollisionEnter(Collision other)
    {
        //もしPlayerが当たったら
        if (other.gameObject.tag == "Player")
        {
            //Playerの値をもらう
            Rigidbody rd = this.GetComponent<Rigidbody>();
            //Vector3 now = rd.position;
            //ポジションを入れる
            Vector3 now = POS;
            //now += POS;
            //rd.position = now;
            //アドホースさせる。
            rd.AddForce(now);
        //rd.AddForce(POS,ForceMode.Force);
            //other.transform.position += POS;
           // Rigidbody rigidbody = GetComponent<Rigidbody>();
           // rigidbody.AddForce(POS);
            //Debug.Log("アドホース");
            
        }
    }
}
