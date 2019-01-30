using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Jyroball : MonoBehaviour
{

    // プレイヤー情報関連を移植（★が移植された物） by KAKIHANA

    // ★プレイヤー操作モード
    public enum Owner
    {
        nosSet = 0, // 初期状態
        player = 1, // プレイヤーが操作している状態
        npc = 2     // NPCモード（自動操縦状態）
    }

    public int playerID = 0;                    // ★自分のID
    public Owner controllMode = Owner.nosSet;   // ★プレイヤーの操縦モード
    [SerializeField] GamePad.Index myPad;       // ★パット識別情報

    [SerializeField] LobbyManager lm;           // ★ロビークラス

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

    void Start()
    {
        // ★ロビークラスコンポーネント取得
        lm = GameObject.FindObjectOfType<LobbyManager>().GetComponent<LobbyManager>();
        // ★子オブジェクトの取得をプレイヤー個別に行えるようにしました
        child = this.transform.Find("huton_0(5)_h").GetComponent<Transform>();         //プレイヤーオブジェクトを探し、transformコンポーネントを取得する
        ballRun = child.GetComponent<ballRun>();                                      //攻撃を受けたかどうかを制御するスクリプトを探し、DamageFlgを使用できるようにする
        // ★全体カメラにするため一旦非表示
        //cameraManeger = GameObject.Find("Main Camera").GetComponent<ControlCamera>(); //メインカメラのスクリプトを参照する
        obutonNum = 0;
    }

    void Update()
    {
        OhutonPointMaster(); //ふとん取得に関するメソッドを常に起動させる

        // ★ロビー状態の場合、ロビークラスに準備完了情報を送る
        if (GamePad.GetButtonDown(GamePad.Button.B, myPad) && lm.sceneMode == LobbyManager.SceneMode.Lobby)
        {
            lm.Entry(myPad);
            // ★プレイヤーの操縦モードを登録する（1P以外）
            if (controllMode == Owner.nosSet)
            {
                controllMode = Owner.player;
            }
        }

        if (lm.sceneMode == LobbyManager.SceneMode.Battle && controllMode == Owner.nosSet)
        {
            controllMode = Owner.npc;
        }

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

            // ★ゲームパッド情報をもとにAxis値を代入
            dir.x = GamePad.GetAxis(GamePad.Axis.LeftStick, myPad).y;
            dir.z = GamePad.GetAxis(GamePad.Axis.LeftStick, myPad).x;
            // ★x値だけ反転してしまうのでdir.xの符号を反転させています
            dir.x = -dir.x;
            //★dir.x = Input.GetAxis("Horizontal");
            //★dir.z = Input.GetAxis("Vertical");

            // ★スティックボタンでも加速できた！！
            if(GamePad.GetButtonDown(GamePad.Button.LeftStick, myPad)){
                Debug.Log("KASOKU");
            }

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
            child.transform.localScale = new Vector3(2.54f, 2.54f, 2.54f);
            //★cameraManeger.moveCameraY = 10.0f;

        }
        else if (obutonNum >= 5 && obutonNum < 10)
        {
            Debug.Log("１段階目！！！");
            rotSpeed = 0.5f;
            child.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
            //★cameraManeger.moveCameraY = 11.0f;
        }
        else if (obutonNum >= 10 && obutonNum < 15)
        {
            Debug.Log("２段階目！！！");
            rotSpeed = 0.45f;
            child.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
            //★cameraManeger.moveCameraY = 12.0f;
        }
        else if (obutonNum >= 15 && obutonNum < 20)
        {
            Debug.Log("３段階目！！！");
            rotSpeed = 0.4f;
            child.transform.localScale = new Vector3(4.5f, 4.5f, 4.5f);
            //★cameraManeger.moveCameraY = 12.5f;
        }
        else if (obutonNum >= 20 && obutonNum < 25)
        {
            Debug.Log("４段階目！！！");
            rotSpeed = 0.35f;
            child.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            //★cameraManeger.moveCameraY = 13.0f;
        }
        else if (obutonNum == 25)
        {
            Debug.Log("５段階目！！！");
            rotSpeed = 0.25f;
            child.transform.localScale = new Vector3(6.0f, 6.0f, 6.0f);
            //★cameraManeger.moveCameraY = 13.5f;
        }
    }

    // ★プレイヤー情報取得
    public void Init(int id)
    {
        playerID = id;  // プレイヤー生成数からIDを取得
        switch (id)     // IDに応じて使用するコントローラーを割り振る
        {
            case 1:
                myPad = GamePad.Index.One;
                controllMode = Owner.player;
                break;
            case 2:
                myPad = GamePad.Index.Two;
                break;
            case 3:
                myPad = GamePad.Index.Three;
                break;
            case 4:
                myPad = GamePad.Index.Four;
                break;
        }
    }
}



