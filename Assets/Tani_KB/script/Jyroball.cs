using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jyroball : MonoBehaviour
{
    public float rotSpeed = 10.0f;//移動スピードの値
    public Vector3 dir;//ジャイロの加速度センサーやGetAxis等の数値を格納する変数
    public Vector3 direction;//ジャイロに伴う回転の数値を格納する変数

    Transform child;　　　　　　//プレイヤーオブジェクト
    BallRun ballRun;　　　　　　 //攻撃を受けたかどうかを制御するスクリプト

    public bool gyroFlg;                //ジャイロ操作の時にONにするフラグ
    public bool debugFlg;　　　　　　   //デバック用のキー操作の時にONにするフラグ

    void Start()
    {
        child = GameObject.Find("huton_muki_tset").GetComponent<Transform>();//プレイヤーオブジェクトを探し、transformコンポーネントを取得する
        ballRun = child.GetComponent<BallRun>();//攻撃を受けたかどうかを制御するスクリプトを探し、DamageFlgを使用できるようにする
    }

    void Update()
    {
        if (gyroFlg == true)
        {
            GyroMove();
        }

        if (debugFlg == true)
        {
            DebugMove();
        }

    }

    //ジャイロ操作統括
    public void GyroMove()
    {

        if (ballRun.DamageFlg == false)
        {
            //攻撃を受けたら動作する
            if (ballRun.DamageFlg == true)
            {
                rotSpeed = 0.0f;
            }

            dir = Vector3.zero;

            // 端末の縦横の表示に合わせてdir変数に格納する
            dir.x = Input.acceleration.x;
            dir.z = Input.acceleration.y;

            if (dir.sqrMagnitude > 1)
                dir.Normalize();

            dir *= Time.deltaTime;

            //実際に動かす
            transform.Translate(dir * rotSpeed);

            if (dir.x != 0.2f || dir.z != 0.2f)
            {
                direction = new Vector3(dir.x, 0, dir.z);
                child.transform.localRotation = Quaternion.LookRotation(direction);
            }
        }
    }

    //デバック用の移動メソッド
    public void DebugMove()
    {
        rotSpeed = 0.5f;

        if (ballRun.DamageFlg == false)
        {
            //diff = Target.position - this.gameObject.transform.position;
            //攻撃を受けたら動作する
            if (ballRun.DamageFlg == true)
            {
                rotSpeed = 0.0f;
            }

            dir.x = Input.GetAxis("Horizontal");
            dir.z = Input.GetAxis("Vertical");

            transform.Translate(dir.x * rotSpeed, 0, dir.z * rotSpeed);

            if (dir.x != 0 || dir.z != 0)
            {
                direction = new Vector3(dir.x, 0, dir.z);
                child.transform.localRotation = Quaternion.LookRotation(direction);
            }
        }
    }
}



