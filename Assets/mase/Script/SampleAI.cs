using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent( typeof( NavMeshAgent ) )]
public class SampleAI : MonoBehaviour
{
    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間
    public bool Playerhit;//Player発見フラグ
    public GameObject target;//追いかけるターゲット
    NavMeshAgent agent;
    public float Accessspeed;
    public bool AIdash;
    public int futongetCount = 0;


    // Use this for initialization
    void Start ()
    {

        //最も近かったオブジェクトを取得
        nearObj = serchTag(gameObject, "point");

        Playerhit = false;

        AIdash = false;

        agent = GetComponent<NavMeshAgent>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (AIdash == false)
        {
            if (Playerhit)
            {
                agent.destination = target.transform.position;
                Debug.Log("きたー");
            }
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

            Debug.Log("フラグがfalse");
        }

        AIfutoncount();
        AIspeedup();
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

    public void AIfutoncount()
    {
        if (futongetCount>=3)
        {
            AIdash = true;
            Debug.Log("3以上になったよ");
        }
    }

    public void AIspeedup()
    {
        if (AIdash == true)
        {
            if (Playerhit)
            {
                agent.destination = target.transform.position;
                Debug.Log("きたー");
            }
            else
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
                transform.Translate(Vector3.forward * Accessspeed * 2);
            }

            Debug.Log("かそくするよ");
        }
    }
}
