﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間
    public bool Playerhit;//Player発見フラグ
    public GameObject target;//追いかけるターゲット
    NavMeshAgent agent;
    public float Accessspeed;
    float stalkerCount;
    public Transform StalkingTarget;//追いかける対象の位置取得
    public float Stalkingspeed = 0.1f;//Stalkingスピード
    private Vector3 vec;

    // Use this for initialization
    void Start ()
    {
        //最も近かったオブジェクトを取得
        nearObj = serchTag(gameObject, "point");

        Playerhit = false;

        stalkerCount = 2.0f;

        //agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Playerhit)
        {
            //targetの方に少しずつ向きが変わる
            transform.rotation = Quaternion.Slerp
                (transform.rotation,
                Quaternion.LookRotation(StalkingTarget.position - transform.position)
                , 0.3f);
            //targetに向かって進む
            transform.position += transform.forward * Stalkingspeed;
            stalkerCount -= Time.deltaTime;
            if (stalkerCount<= 0)
            {
                Playerhit = false;
                Debug.Log("反転");
            }
            //agent.destination = target.transform.position;
            //stalkerCount -= Time.deltaTime;
            //if (stalkerCount<=0)
            //{
            //    Playerhit = false;

            //}

        }
        if(Playerhit == false)
        {
            //経過時間を取得
            searchTime += Time.deltaTime;

            if (searchTime >= 1.0f)
            {
                //最も近かったオブジェクトを取得
                nearObj = serchTag(gameObject, "point");

                //経過時間を初期化
                searchTime = 0;
            }

            //対象の位置の方向を向く
            transform.LookAt(nearObj.transform);

            //transform.rotation(nearObj.transform)


            //自分自身の位置から相対的に移動する
            transform.Translate(Vector3.forward * Accessspeed);

            stalkerCount = 3;
            Debug.Log("フラグがfalse");
        }
    }

    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;


    }
}
