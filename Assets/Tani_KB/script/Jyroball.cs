using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jyroball : MonoBehaviour
{
    public float rotSpeed;　         //移動スピードの値
    public Vector3 dir;　　　　　    //ジャイロに伴う傾けた方向に進む数値を格納する変数
    public Vector3 rot;              //ジャイロに伴う回転の数値を格納する変数
    public float customDirX;         //dirとrotの小数点第２以下を切り捨てるための借り入れ変数(x座標版)
    public float customDirZ;         //dirとrotの小数点第２以下を切り捨てるための借り入れ変数(z座標版)

    public int obutonNum;           //取得した布団の数を格納する変数

    Transform child;　　　　　　 　  //プレイヤーオブジェクト
    ballRun ballRun;　　　　　　     //攻撃を受けたかどうかを制御するスクリプト
    ControlCamera cameraManeger;     //メインカメラのスクリプトを参照する変数

    public bool gyroFlg;             //ジャイロ操作の時にONにするフラグ

    public GameObject Step_0;
    public GameObject Step_1;
    public GameObject Step_2;
    public GameObject Step_3;
    public GameObject Step_4;
    public GameObject Step_5;

    public bool s0;
    public bool s1;
    public bool s2;
    public bool s3;
    public bool s4;
    public bool s5;
    void Start()
    {
        Step_0.SetActive(true);
        Step_1.SetActive(false);
        Step_2.SetActive(false);
        Step_3.SetActive(false);
        Step_4.SetActive(false);
        Step_5.SetActive(false);

        child = GameObject.Find("huton_0(5)_h").GetComponent<Transform>();         //プレイヤーオブジェクトを探し、transformコンポーネントを取得する
        ballRun = child.GetComponent<ballRun>();                                      //攻撃を受けたかどうかを制御するスクリプトを探し、DamageFlgを使用できるようにする
        cameraManeger = GameObject.Find("Main Camera").GetComponent<ControlCamera>(); //メインカメラのスクリプトを参照する
        obutonNum = 0;
    }

    void Update()
    {
        if (s0 == true)
        {
            child = GameObject.Find("huton_0(5)_h").GetComponent<Transform>();         //プレイヤーオブジェクトを探し、transformコンポーネントを取得する
            ballRun = child.GetComponent<ballRun>();
        }
        if (s1 == true)
        {
            child = GameObject.Find("huton_1(15)_h").GetComponent<Transform>();         //プレイヤーオブジェクトを探し、transformコンポーネントを取得する
            ballRun = child.GetComponent<ballRun>();
        }
        if (s2 == true)
        {
            child = GameObject.Find("huton_2(20)_h").GetComponent<Transform>();         //プレイヤーオブジェクトを探し、transformコンポーネントを取得する
            ballRun = child.GetComponent<ballRun>();
        }
        if (s3 == true)
        {
            child = GameObject.Find("huton_3(31)_h").GetComponent<Transform>();         //プレイヤーオブジェクトを探し、transformコンポーネントを取得する
            ballRun = child.GetComponent<ballRun>();
        }
        if (s4 == true)
        {
            child = GameObject.Find("huton_4(46)_h").GetComponent<Transform>();         //プレイヤーオブジェクトを探し、transformコンポーネントを取得する
            ballRun = child.GetComponent<ballRun>();
        }
        if (s5 == true)
        {
            child = GameObject.Find("huton_5(81)_h").GetComponent<Transform>();         //プレイヤーオブジェクトを探し、transformコンポーネントを取得する
            ballRun = child.GetComponent<ballRun>();
        }

        OhutonPointMaster(); //ふとん取得に関するメソッドを常に起動させる

        //gyroflgのON，OFFでスマホ操作かPC操作を切り替えられる
        if (gyroFlg == true)
        {
            GyroMove();
        }

        if (gyroFlg == false)
        {
            DebugMove();
        }

        
    }

    //ふとん取得に関するメソッド
    public void OhutonPointMaster()
    {
        if (Input.GetKeyDown(KeyCode.N)) //現状はＮキー操作でふえる仕組み
        {
            if (obutonNum < 25)
            {
                obutonNum += 1;
            }

        }
        if (Input.GetKeyDown(KeyCode.M)) //現状はＭキー操作でふえる仕組み
        {
            if (obutonNum > 0)
            {
                obutonNum -= 1;
            }
        }
    }

    //ジャイロ操作統括
    public void GyroMove()
    {
        //ジャイロ操作では10.0fに設定する。
        rotSpeed = 10.0f;
        CustomPlayerScale();

        if (gyroFlg == true)
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


            //スマホ操作で極力動かさないようにすると移動や回転が止まる。
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
        //キー操作では0.1fに設定する。
        rotSpeed = 0.1f;
        CustomPlayerScale();

        if (gyroFlg == false)
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
        if(obutonNum >= 0 && obutonNum < 5)
        {
            Debug.Log("初期状態！！！");
            rotSpeed = 0.6f;
            //child.transform.localScale = new Vector3(2.54f, 2.54f, 2.54f);
            cameraManeger.moveCameraY = 10.0f;
            Step_0.SetActive(true);
            Step_1.SetActive(false);
            s0 = true;
            s1 = false;

        }
        else if (obutonNum >= 5 && obutonNum < 10)
        {
            Debug.Log("１段階目！！！");
            rotSpeed = 0.5f;
            //child.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
            cameraManeger.moveCameraY = 11.0f;
            Step_0.SetActive(false);
            Step_1.SetActive(true);
            Step_2.SetActive(false);
            s0 = false;
            s1 = true;
            s2 = false;
        }
        else if (obutonNum >= 10 && obutonNum < 15)
        {
            Debug.Log("２段階目！！！");
            rotSpeed = 0.45f;
            //child.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
            cameraManeger.moveCameraY = 12.0f;
            Step_1.SetActive(false);
            Step_2.SetActive(true);
            Step_3.SetActive(false);
            s1 = false;
            s2 = true;
            s3 = false;
        }
        else if (obutonNum >= 15 && obutonNum < 20)
        {
            Debug.Log("３段階目！！！");
            rotSpeed = 0.4f;
            //child.transform.localScale = new Vector3(4.5f, 4.5f, 4.5f);
            cameraManeger.moveCameraY = 12.5f;
            Step_2.SetActive(false);
            Step_3.SetActive(true);
            Step_4.SetActive(false);
            s2 = false;
            s3 = true;
            s4 = false;
        }
        else if (obutonNum >= 20 && obutonNum < 25)
        {
            Debug.Log("４段階目！！！");
            rotSpeed = 0.35f;
            //child.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            cameraManeger.moveCameraY = 13.0f;
            Step_3.SetActive(false);
            Step_4.SetActive(true);
            Step_5.SetActive(false);
            s3 = false;
            s4 = true;
            s5 = false;
        }
        else if (obutonNum == 25)
        {
            Debug.Log("５段階目！！！");
            rotSpeed = 0.25f;
            //child.transform.localScale = new Vector3(6.0f, 6.0f, 6.0f);
            cameraManeger.moveCameraY = 13.5f;
            Step_4.SetActive(false);
            Step_5.SetActive(true);
            s4 = false;
            s5 = true;
        }
    }
}



