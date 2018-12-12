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

    public float cntTime;　　　　　　　　　　　 //実際の時間制限
    public int checkTime;　　　　　　　　　　　 //時間制限（float）をswitch文で使えるようにする変数



    // Use this for initialization
    void Start ()
    {
        cntTime = 0.0f;　　　　　　　　　　　　 //時間に関する数値の変数を初期化
        checkTime = 0;
        teacherImg.SetBool("TimerStart", false);//タイマー（先生）を起動
        animScript = AnimMas.GetComponent<AnimScript>();//アニメーションスクリプトを指定
    }

    // Update is called once per frame
    void Update()
    {
        //タイマー発動
        if (cntTime<=120.0f)
        {
            TimeCounter();
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

    //タイマー管理
    public void TimeCounter()
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
