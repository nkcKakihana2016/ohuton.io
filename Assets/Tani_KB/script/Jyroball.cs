using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jyroball : MonoBehaviour
{
    float inputHorizontal = 2.0f;
    float inputVertical;

    private Quaternion gyro;


    public float moveSpeed = 3f;//プレイヤーのスピード

    //float inputGyro;

    GameObject child;
    BallRun ballRun;

    void Start()
    {
        child = GameObject.Find("human");
        ballRun = child.GetComponent<BallRun>();

        Input.gyro.enabled = true;
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
            JyroMove();
        }
        if(ballRun.DamageFlg==true)
        {
            //PlayerObjのZ軸方向に向かって進む
            transform.Translate(new Vector3(0, 0, 0));
        }

    }


    //ジャイロ操作統括
    public void JyroMove()
    {
        if(gyro.y > 0.02|| gyro.y < -0.05)
        {
            transform.Rotate(0, -gyro.y * 15, 0);
        }

        //if (gyro.x < -0.5)
        //{
        //    transform.Rotate(0, -gyro.y * 15, 0);
        //}
        //else if (gyro.x < -0.5 || gyro.y < 0.1)
        //{
        //    transform.Rotate(0, gyro.y * 15, 0);
        //}

    }
}
