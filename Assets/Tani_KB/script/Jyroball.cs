using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jyroball : MonoBehaviour
{
    //private float rotSpeed = 10.0f;

    //private Vector3 dir;

    float inputHorizontal = 2.0f;
    float inputVertical;


    public float moveSpeed = 3f;//プレイヤーのスピード

    GameObject child;
    BallRun ballRun;

    void Start()
    {
        child = GameObject.Find("human");
        ballRun = child.GetComponent<BallRun>();

    }

    void Update()
    {
        if(ballRun.DamageFlg==false)
        {
            //PlayerObjのZ軸方向に向かって進む
            transform.Translate(new Vector3(0, 0, moveSpeed) * Time.deltaTime);

            //左右キーで進行角度を変化させる
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");

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
        //    dir = Vector3.zero;

        //    dir.y = Input.acceleration.z;

        //    if (dir.sqrMagnitude > 1)
        //        dir.Normalize();

        //    dir *= Time.deltaTime;

        //    transform.Rotate(dir * rotSpeed);
        transform.Rotate(0, inputHorizontal*2, 0);

        if(inputVertical>0.5)
        {
            transform.Rotate(0, inputHorizontal * 4, 0);
        }
    }
}
