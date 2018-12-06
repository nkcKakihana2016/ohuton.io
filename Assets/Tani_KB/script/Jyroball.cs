using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jyroball : MonoBehaviour
{
    public float rotSpeed;　         //移動スピードの値
    public float accelSpeed;         //加速スピードの値
    public Vector3 dir;　　　　　    //ジャイロに伴う傾けた方向に進む数値を格納する変数
    public Vector3 rot;              //ジャイロに伴う回転の数値を格納する変数
    public float customDirX;
    public float customDirZ;

    public int zabutonNum;           //取得した布団の数を格納する変数

    Transform child;　　　　　　 　  //プレイヤーオブジェクト
    BallRun ballRun;　　　　　　     //攻撃を受けたかどうかを制御するスクリプト
    ControlCamera cameraManeger;     //メインカメラのスクリプトを参照する変数

    public bool gyroFlg;             //ジャイロ操作の時にONにするフラグ
    bool stopFlg;

    void Start()
    {
        child = GameObject.Find("huton_muki_tset").GetComponent<Transform>();         //プレイヤーオブジェクトを探し、transformコンポーネントを取得する
        ballRun = child.GetComponent<BallRun>();                                      //攻撃を受けたかどうかを制御するスクリプトを探し、DamageFlgを使用できるようにする
        cameraManeger = GameObject.Find("Main Camera").GetComponent<ControlCamera>(); //メインカメラのスクリプトを参照する
        stopFlg = false;
        zabutonNum = 0;
    }

    void Update()
    {
        //gyroflgのON，OFFでスマホ操作かPC操作を切り替えられる
        if (gyroFlg == true)
        {
            GyroMove();
        }

        if (gyroFlg == false)
        {
            DebugMove();

            if(Input.GetKeyDown(KeyCode.N))
            {
                if(zabutonNum < 25)
                {
                   zabutonNum += 1;
                }
               
            }
            if(Input.GetKeyDown(KeyCode.M))
            {
                if(zabutonNum > 0)
                {
                    zabutonNum -= 1;
                }
            }
        }
    }

    //ジャイロ操作統括
    public void GyroMove()
    {
        rotSpeed = 10.0f;
        CustomPlayerScale();

        if (ballRun.DamageFlg == false)
        {
            Vector3 inDir = Vector3.zero;

            // 端末の縦横の表示に合わせてdir変数に格納する
            inDir.x = Input.acceleration.x;
            inDir.z = Input.acceleration.y;

            customDirX = inDir.x;
            customDirZ = inDir.z;

            //小数点第2以下を切り捨てるよう計算しなおす
            customDirX = Mathf.Floor(customDirX * 200) / 2000;
            customDirZ = Mathf.Floor(customDirZ * 200) / 2000;

            //customDirX = Mathf.Clamp(customDirX, 0.01f, -0.01f);
            //customDirZ = Mathf.Clamp(customDirZ, 0.01f, -0.01f);



            if (customDirX < 0.01 || customDirX > -0.01)
            {
                if (customDirZ < 0.01 || customDirZ > -0.01)
                {
                    dir = new Vector3(customDirX, 0, customDirZ);
                    rotSpeed = 0.0f;
                    transform.Translate(dir * rotSpeed);
                }
            }

            if (customDirX > 0.01 || customDirX < -0.01)
            {
                if (customDirZ > 0.01 || customDirZ < -0.01)
                {
                    //実際に動かす
                    dir = new Vector3(customDirX, 0, customDirZ);
                    rotSpeed = 10.0f;
                    transform.Translate(dir * rotSpeed);

                    //指定した範囲内の数値では回転しないようにする
                    rot = new Vector3(customDirX, 0, customDirZ);
                    child.transform.localRotation = Quaternion.LookRotation(rot);
                }
            }
            
            //if (dir.sqrMagnitude > 1)
            //    dir.Normalize();

            //dir *= Time.deltaTime;



            //方向を計算して回転させる
            //Vector3 directRot = new Vector3(dir.x, 0, dir.z);
            //float dirRotX = dir.x;
            //float dirRotZ = dir.z;
            //dirRotX = Mathf.Floor(dirRotX * 200) / 2000;
            //dirRotZ = Mathf.Floor(dirRotZ * 200) / 2000;

            //if (dir.x != 0 || dir.z != 0)
            //{
            //    rot = new Vector3(dirRotX, 0, dirRotZ);
            //    child.transform.localRotation = Quaternion.LookRotation(rot);
            //}
        }
    }

    //デバック用の移動メソッド
    public void DebugMove()
    {
        rotSpeed = 0.1f;
        CustomPlayerScale();

        if (ballRun.DamageFlg == false)
        {
            //diff = Target.position - this.gameObject.transform.position;
            Vector3 dir = Vector3.zero;

            dir.x = Input.GetAxis("Horizontal");
            dir.z = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.Space))
            {
                rotSpeed *= 1.5f;
            }

            transform.Translate(dir.x * rotSpeed, 0, dir.z * rotSpeed);

            if (dir.x != 0 || dir.z != 0)
            {
                rot = new Vector3(dir.x, 0, dir.z);
                child.transform.localRotation = Quaternion.LookRotation(rot);
            }
        }
    }

    //子オブジェクトのサイズ変更と初期スピードの変更を司るメソッド
    public void CustomPlayerScale()
    {
        if(zabutonNum >= 0 && zabutonNum < 5)
        {
            Debug.Log("初期状態！！！");
            rotSpeed = 0.6f;
            child.transform.localScale = new Vector3(2.54f, 2.54f, 2.54f);
            cameraManeger.moveCameraY = 10.0f;

        }
        else if (zabutonNum >= 5 && zabutonNum < 10)
        {
            Debug.Log("１段階目！！！");
            rotSpeed = 0.5f;
            child.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
            cameraManeger.moveCameraY = 11.0f;
        }
        else if (zabutonNum >= 10 && zabutonNum < 15)
        {
            Debug.Log("２段階目！！！");
            rotSpeed = 0.45f;
            child.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
            cameraManeger.moveCameraY = 12.0f;
        }
        else if (zabutonNum >= 15 && zabutonNum < 20)
        {
            Debug.Log("３段階目！！！");
            rotSpeed = 0.4f;
            child.transform.localScale = new Vector3(4.5f, 4.5f, 4.5f);
            cameraManeger.moveCameraY = 12.5f;
        }
        else if (zabutonNum >= 20 && zabutonNum < 25)
        {
            Debug.Log("４段階目！！！");
            rotSpeed = 0.35f;
            child.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            cameraManeger.moveCameraY = 13.0f;
        }
        else if (zabutonNum == 25)
        {
            Debug.Log("５段階目！！！");
            rotSpeed = 0.25f;
            child.transform.localScale = new Vector3(6.0f, 6.0f, 6.0f);
            cameraManeger.moveCameraY = 13.5f;
        }
    }
}



