using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image roadImg;　　　　　　　　　　 　//タイマー（廊下）をアタッチ
    public Animator teacherImg;　　　　　　　　 //タイマー（先生）をアタッチ
    public GameObject Husuma;                   //ふすまの親オブジェクトをアタッチ
    public GameObject AnimMas;                  //アニメーション統括オブジェクトをアタッチ
    AnimScript animScript;　　　　　　　　　　　//アニメーションスクリプトを格納
    HusumaOC husuma;

    [SerializeField]
    private float cntTime;　　　　　　　　　　　 //実際の時間制限
    [SerializeField]
    private int checkTime;                       //時間制限（float）をswitch文で使えるようにする変数
        
    bool timeFlg;                               //時間制限のONOFFを指定するフラグ 


    // Use this for initialization
    void Start ()
    {
        cntTime = 0.0f;　　　　　　　　　　　　         //実際の時間制限の変数を初期化
        checkTime = 0;                                  //時間制限（float）をswitch文で使えるようにする変数を初期化

        animScript = AnimMas.GetComponent<AnimScript>();                 //アニメーションスクリプトを指定
        husuma = GameObject.Find("Husuma_test").GetComponent<HusumaOC>();//ふすまアニメションとスクリプトを指定

        teacherImg.SetBool("TimerStart", false);//タイマー（先生）を起動
        timeFlg = false;                        //ゲームシーン開始時に即時動作しないようにOFFにする。
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("LateStarting", 1.0f);//１秒遅らせてStartメソッドの後に発動させる

        if (timeFlg==true)
        {
            //タイマー発動
            if (cntTime <= 120.0f)
            {
                TimeCounter();
            }
            //タイマー終了時
            if (checkTime == 121)
            {
                Invoke("LateChangeScene", 2.0f);
            }
        }

        ////ふすまのアニメーションを指定
        //// 次のシーンへ飛ぶときに使う
        //if (Input.GetKey(KeyCode.A))
        //{
        //    animScript.husumaEfe = 1;
        //    animScript.ChangeScene();
        //}
        ////ゲームシーンの最初に使う
        //if (Input.GetKey(KeyCode.S))
        //{
        //    animScript.husumaEfe = 2;
        //    animScript.ChangeScene();
        //}
        ////リザルトの最初に使う
        //if (Input.GetKey(KeyCode.D))
        //{
        //    animScript.husumaEfe = 3;
        //    animScript.ChangeScene();
        //}
    }

    //リザルトシーンへ移行する際にアニメーションを遅らせるためのメソッド
    void LateChangeScene()
    {
        husuma.ChangeScene();
    }

    //Startメソッドの後に発動させるメソッド
    void LateStarting()
    {
        husuma.AnimNum = 2;
        husuma.ChangeScene();
        husuma.AnimNum = 1;
        timeFlg = true;
    }

    //タイマー管理
    void TimeCounter()
    {
        teacherImg.SetBool("TimerStart", true); //タイマー（先生）を起動
        cntTime += Time.deltaTime;
        checkTime = Mathf.CeilToInt(cntTime);   //cntTimeをint型に変更したものを保存

        //指定された時間ごとの処理（cntTimeよりcheckTimeのほうが1秒早い）
        switch (checkTime)
        {
            case 61://制限時間が60秒になった時
                animScript.timerEfe = 1;
                animScript.TimerSerif();
                Debug.Log("60秒経過");
                break;
            case 91://制限時間が90秒になった時
                animScript.timerEfe = 2;
                animScript.TimerSerif();
                Debug.Log("90秒経過");
                break;
            case 121://制限時間が120秒（ゲーム終了）になった時
                animScript.timerEfe = 3;
                animScript.TimerSerif();
                Debug.Log("ゲーム終了");
                break;
        }
    }
}
