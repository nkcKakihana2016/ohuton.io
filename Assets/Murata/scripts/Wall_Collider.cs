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
    void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("触れたよ");
            other.transform.position += POS;
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(POS);
            
        }
    }
}
