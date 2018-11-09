﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jyroball : MonoBehaviour
{

    //const float Gravity = 2.81f;
    //public float gravityScale = 1.0f;
    //public float angle;
    public Transform Target;

    public float rotSpeed = 10.0f;//移動スピードの値
    public Vector3 dir;
    public int gyroRot;     //プレイヤー角度を調整するswitch文ようの変数

    private Vector3 diff;
    //private Vector3 axis;
    //private Vector3 angle;
    float angle = 1;

    GameObject child;　　　　　　//プレイヤーオブジェクト
    BallRun ballRun;　　　　　　 //攻撃を受けたかどうかを制御するスクリプト

    public　bool gyroFlg;                //ジャイロ操作の時にONにするフラグ
    public bool debugFlg;　　　　　　   //デバック用のキー操作の時にONにするフラグ

    void Start()
    {
        child = GameObject.Find("human");//プレイヤーオブジェクトを探す
        ballRun = child.GetComponent<BallRun>();//攻撃を受けたかどうかを制御するスクリプトを探し、DamageFlgを使用できるようにする
        Target = GameObject.Find("targetObj").GetComponent<Transform>();//オブジェクトを探す


         gyroRot = 0;
    }

    void Update()
    {
        if(gyroFlg==true)
        {
            GyroMove();
        }

        if(debugFlg==true)
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
        }

        switch (gyroRot)
        {
            case 1://dir.xがプラス方向になった時、右を向く
                child.transform.eulerAngles = new Vector3(0, 90, -90);
                break;
            case 2://dir.xがマイナス方向になった時、左を向く
                child.transform.eulerAngles = new Vector3(0, -90, -90);
                break;
            case 3://dir.zがプラス方向になった時、上を向く
                child.transform.eulerAngles = new Vector3(0, 0, -90);
                break;
            case 4://dir.zがマイナス方向になった時、下を向く
                child.transform.eulerAngles = new Vector3(0, 180, -90);
                break;
        }

        //if (ballRun.charaRot.y)//右を向く
        //{
        //    gyroRot = 1; 
        //}

        //if (dir.x < -0.04f)//左を向く
        //{
        //    gyroRot = 2; 
        //}

        //if (dir.z > 0.05f)//上を向く
        //{
        //    gyroRot = 3;
        //}

        //if (dir.z < -0.05f)//下を向く
        //{
        //    gyroRot = 4;
        //}


        if (dir.x > 0.04f)//右を向く
        {
            gyroRot = 1;
            //if (child.transform.rotation.y == 0 && child.transform.rotation.y == 180)
            //{

            //    child.transform.eulerAngles = new Vector3(0, 90, -90);
            //    gyroRot = 1;
            //}
        }

        if (dir.x < -0.04f)//左を向く
        {
            gyroRot = 2;
            //if (child.transform.rotation.y == 0 && child.transform.rotation.y == 180)
            //{
            //    child.transform.eulerAngles = new Vector3(0, -90, -90);
            //    gyroRot = 2;
            //}
        }

        if (dir.z > 0.05f)//上を向く
        {
            //child.transform.eulerAngles = new Vector3(0, 0, -90);
            gyroRot = 3;
        }

        if (dir.z < -0.05f)//下を向く
        {
            //child.transform.eulerAngles = new Vector3(0, 180, -90);
            gyroRot = 4;
        }



        //if (gyro.y < -0.1)
        //{
        //    gyroRot = 1;
        //    transform.Rotate(0, -gyro.y * 15, 0);
        //}

        //if (gyro.y > 0.1)
        //{
        //    gyroRot = 0;
        //    //transform.Rotate(0, -gyro.y * 15, 0);
        //}
    }

    //デバック用の移動メソッド
    public void DebugMove()
    {
        rotSpeed = 0.5f;

        if(ballRun.DamageFlg==false)
        {
            diff = Target.position - this.gameObject.transform.position;
            //攻撃を受けたら動作する
            if (ballRun.DamageFlg == true)
            {
                rotSpeed = 0.0f;
            }

            dir.x = Input.GetAxis("Horizontal") * rotSpeed;
            dir.z = Input.GetAxis("Vertical") * rotSpeed;

            transform.Translate(dir.x, 0, dir.z);
        }

        if(dir.x !=0 || dir.z !=0)
        {
            
        }

        //switch (gyroRot)
        //{
        //    case 1://dir.xがプラス方向になった時、右を向く
        //        Target.transform.localPosition = new Vector3(1.5f, 0, 0);
        //        //child.transform.eulerAngles = new Vector3(0, 90, -90);
        //        break;
        //    case 2://dir.xがマイナス方向になった時、左を向く
        //        Target.transform.localPosition = new Vector3(-1.5f, 0, 0);
        //        //child.transform.eulerAngles = new Vector3(0, -90, -90);
        //        break;
        //    case 3://dir.zがプラス方向になった時、上を向く
        //        Target.transform.localPosition = new Vector3(0, 0, 1.5f);
        //        //child.transform.eulerAngles = new Vector3(0, 0, -90);
        //        break;
        //    case 4://dir.zがマイナス方向になった時、下を向く
        //        Target.transform.localPosition = new Vector3(0, 0, -1.5f);
        //        //child.transform.eulerAngles = new Vector3(0, 180, -90);
        //        break;
        //}

        //if(dir.x > 0.3f)
        //{
        //    gyroRot = 1;
        //}
        //if (dir.x < -0.3f)
        //{
        //    gyroRot = 2;
        //}
        //if (dir.z > 0.3f)
        //{
        //    gyroRot = 3;
        //}
        //if (dir.z < -0.3f)
        //{
        //    gyroRot = 4;
        //}
    }
}


