﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jyroball : MonoBehaviour
{
    float inputHorizontal = 2.0f;
    float inputVertical;

    private Quaternion gyro;


    public float moveSpeed = 3f;//プレイヤーのスピード

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
        transform.Rotate(0, -gyro.y*10, 0);

        if (gyro.x > 0.35 ||gyro.x < -0.35)
        {
            transform.Rotate(0, gyro.y * 15, 0);
        }
    }
}
