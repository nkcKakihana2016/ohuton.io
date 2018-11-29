﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : Photon.MonoBehaviour {

    // キャラクタースクリプト Photon動作確認用

    // オンラインに必要なコンポーネントを設定
    public PhotonView myPhotonView;
    public PhotonTransformView myPhotonTransformView;

    public GameMaster gm;
    public PlayerData myData;

    // 自分のPhotonViewID
    /* ViewIDについての補足 */
    /*
    ViewIDはプレイヤーごとに千の倍数で振り分けられる
    例：
    プレイヤー１ ViewID:1001
    プレイヤー２ ViewID:2001
    プレイヤーＣ ViewID:3001
    */
    [SerializeField] int myViewId;
    [SerializeField] int viewid;
    public int myID = 0;

    // 使用するキャラクターコントローラー
    public CharacterController myCC;

    // カメラ情報
    private Camera mainCam;

    // スピード
    public float speed;
    // 移動ベクトル
    Vector3 pos = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        myData = this.gameObject.GetComponent<PlayerData>();
        this.myPhotonView = PhotonView.Get(this);
        gm.idList.Add(myPhotonView.viewID);
        gm.playerDataList.Add(myData);
        // Photonに接続されていたら
        if (myPhotonView.isMine)
        {
            // カメラ情報を取得
            mainCam = Camera.main;
            // カメラスクリプト内にあるターゲット座標変数に自キャラの座標を格納
            mainCam.GetComponent<CameraManager>().target = this.gameObject.transform;
            // PhotonviewよりviewIDを取得
            myViewId = photonView.viewID;

            //myID = photonView.RPC("GetID", PhotonTargets.AllViaServer);
           // ViewIDの千の位によりプレイヤーの色を変える
            switch (myViewId /= 1000)
            {
                case 1:
                    this.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                    break;
                case 2:
                    this.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
                    break;
                case 3:
                    this.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
                    break;
                case 4:
                    this.GetComponent<Renderer>().material.color = new Color(100, 255, 255);
                    break;
                case 5:
                    this.GetComponent<Renderer>().material.color = new Color(255, 0, 255);
                    break;
                case 6:
                    this.GetComponent<Renderer>().material.color = new Color(255, 255, 100);
                    break;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        // Photonに接続されていなければ操作できないようにする
        if (!myPhotonView.isMine)
        {
            return;
        }
        Move(); // 移動ベクトル計算メソッド起動
        myCC.Move(pos * Time.deltaTime); // キャラクター移動

        // 同期ズレを減らすためにPhotonTransformViewに送信する移動用ベクトルを
        // キャラクターコントローラーのスピードより取得
        Vector3 velocity = myCC.velocity;
        // 移動用ベクトルをPhotonTransformViewに送信
        myPhotonTransformView.SetSynchronizedValues(velocity, 0);
    }

    void Move()
    {
        // 移動量算出（ベータ版）
        pos.x = Input.GetAxis("Horizontal");
        pos.z = Input.GetAxis("Vertical");
    }

    public void SendToMasterReady()
    {
        gm.ReadyCount();
    }

    // PunRPC以外の同期方法としてOnPhotonSerializeView（）関数下でも出来る
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting) { /* 書き込み処理 */
        }
        else { /* 読み込み処理 */
        }
    }

    
    
}
