using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jyroball : MonoBehaviour
{
    public float rotSpeed = 0.0f;//移動スピードの値
    public int gyroRot;　　　　　//プレイヤー角度を調整するswitch文ようの変数

    GameObject child;　　　　　　//プレイヤーオブジェクト
    BallRun ballRun;　　　　　　 //攻撃を受けたかどうかを制御するスクリプト

    void Start()
    {
        child = GameObject.Find("human");//プレイヤーオブジェクトを探す
        ballRun = child.GetComponent<BallRun>();//攻撃を受けたかどうかを制御するスクリプトを探し、DamageFlgを使用できるようにする

        gyroRot = 2;
    }

    void Update()
    {
        if (ballRun.DamageFlg == false)
        {
            //攻撃を受けたら動作する
            if (ballRun.DamageFlg == true)
            {
                rotSpeed = 0.0f;
            }

            var dir = Vector3.zero;

            // 端末の縦横の表示に合わせてdir変数に格納する
            dir.x = Input.acceleration.x;
            dir.z = Input.acceleration.y;

            // clamp acceleration vector to the unit sphere
            if (dir.sqrMagnitude > 1)
                dir.Normalize();

            // Make it move 10 meters per second instead of 10 meters per frame...
            dir *= Time.deltaTime;

            //実際に動かす
            transform.Translate(dir * rotSpeed);
        }
    }

    //ジャイロ操作統括
    //public void GyroMove()
    //{
    //    switch (gyroRot)
    //    {
    //        case 0://gyro.yがプラス方向になった時
    //            transform.Rotate(0, -90, 0);
    //            break;
    //        case 1://gyro.yがマイナス方向になった時
    //            transform.Rotate(0, 90, 0);
    //            break;
    //        case 2://gyro.xがプラス方向になった時
    //            transform.Rotate(0, 0, 0);
    //            break;
    //        case 3://gyro.xがマイナス方向になった時
    //            transform.Rotate(0, 180, 0);
    //            break;
    //    }
    //    if (gyro.y < -0.09 || gyro.y > -0.17)
    //    {
    //        transform.Rotate(0, -gyro.y * 0, 0);
    //    }

    //    if (gyro.y < -0.1)
    //    {
    //        gyroRot = 1;
    //        //transform.Rotate(0, -gyro.y * 15, 0);
    //    }

    //    if (gyro.y > 0.1)
    //    {
    //        gyroRot = 0;
    //        //transform.Rotate(0, -gyro.y * 15, 0);
    //    }
    //}
}
