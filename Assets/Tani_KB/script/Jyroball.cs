using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jyroball : MonoBehaviour
{
    float inputHorizontal = 2.0f;
    float inputVertical;

    private Quaternion gyro;


    public float moveSpeed = 3f;//プレイヤーのスピード
    public float inputRot;

    //float inputGyro;

    GameObject child;
    BallRun ballRun;

    void Start()
    {
        child = GameObject.Find("human");
        ballRun = child.GetComponent<BallRun>();

        Input.gyro.enabled = true;

        inputRot = 0.0f;
    }

    void Update()
    {
        this.gyro = Input.gyro.attitude;

        if(ballRun.DamageFlg==false)
        {
            //PlayerObjのZ軸方向に向かって進む
            transform.Translate(new Vector3(0, 0, moveSpeed) * Time.deltaTime);

            //左右キーで進行角度を変化させる
            //inputHorizontal = Input.GetAxisRaw("Horizontal");
            //inputVertical = Input.GetAxisRaw("Vertical");

            //ジャイロ操作のメソッド呼び出し
            GyroMove();
        }
        if(ballRun.DamageFlg==true)
        {
            //PlayerObjのZ軸方向に向かって進む
            transform.Translate(new Vector3(0, 0, 0));
        }
    }


    //ジャイロ操作統括
    public void GyroMove()
    {
        //if(gyro.x<0.3||gyro.x>-0.3)
        //{
        //    if(gyro.y<-0.09||gyro.y>-0.17)
        //    {
        //        transform.Rotate(0, -gyro.y * 0, 0);
        //    }

            if (gyro.y < -0.1)
            {
                transform.Rotate(0, -gyro.y * 15, 0);
            }

            if (gyro.y > 0.1)
            {
                transform.Rotate(0, -gyro.y * 15, 0);
            }
        //}
       
    }
}
