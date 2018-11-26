using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 壁スクリプト
/// </summary>
public class Wall_Collider : MonoBehaviour
{

    GameObject PlayerObject;

    [SerializeField]
    //座標
    Vector3 POS;
    void Start()
    {
        PlayerObject = GameObject.Find("human");
    }


    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerObject.transform.position += POS;
        }
    }
}
