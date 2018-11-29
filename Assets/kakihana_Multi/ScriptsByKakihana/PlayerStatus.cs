using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerStatus : Photon.PunBehaviour,IPunObservable{

    // ネットワーク用プレイヤー管理クラス
    /*
     【このクラスの役割】
      １．使用するUIを生成させる
      ２．オンラインでUIを共有させるために自身の情報を使用するUIに設定する
      （Instantiate<>に直接引数を渡せない為、生成した後にコンポーネント取得し、自分のデータを渡す）
     */

    public GameObject playerUIPrefab;   // 名前表示UIのゲームオブジェクト
    public GameObject playerIconPrefab; // 準備完了状況を表示させるUI

    public static GameObject localPlayer; // プレイヤーのローカルオブジェクト

    [SerializeField] GameObject statusUI; // UIキャンバスに設定するためのオブジェクト
    [SerializeField] GameObject playerIconUI; // UIキャンバスに設定するためのオブジェクト

    public PlayerData myData;             // 自分のデータ

    public GameObject readyButtonObj;   // 準備完了ボタン
    void Awake()
    {
        // Photonに接続されていれば
        if (photonView.isMine)
        {
            // ローカルオブジェクトに自身のオブジェクトを設定
            PlayerStatus.localPlayer = this.gameObject;
        }
        // 自分のキャラクターデータクラスのコンポーネント取得
        myData = this.gameObject.GetComponent<PlayerData>();
    }

	// Use this for initialization
	void Start () {
        if (playerUIPrefab != null)
        {
            // プレイヤー名UIプレファブがアタッチされていたら生成する
            statusUI = Instantiate(playerUIPrefab) as GameObject;
            // PlayerNameUIスクリプト内にあるSetTarget()に情報を送信
            statusUI.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
        }
        else
        {

        }
        if (playerIconPrefab != null) // アイコンプレファブが設定されていたら
        {
            // プレイヤー情報を関連付けるためのアイコンクラスを用意
            IconManager iconManager; 
            // ゲームオブジェクトとしてアイコンを生成
            playerIconUI = Instantiate(playerIconPrefab) as GameObject;
            // アイコンクラスコンポーネント取得
            iconManager = playerIconUI.GetComponent<IconManager>();
            // アイコンクラスとプレイヤー情報を関連付ける
            iconManager.IconDataInit(myData);
        }
        if(readyButtonObj != null) // 準備完了ボタンプレファブが設定されていたら
        {
            // プレイヤー情報を関連付ける為のクラスを用意
            ReadyButtonTransform readyBtn;
            // ゲームオブジェクトとして準備完了ボタンを生成
            readyButtonObj = Instantiate(readyButtonObj) as GameObject;
            // 準備完了ボタンクラスのコンポーネント取得
            readyBtn = readyButtonObj.GetComponent<ReadyButtonTransform>();
            // 準備完了ボタンクラスとプレイヤー情報を関連付ける
            readyBtn.dataInit(myData);
        }
	}
	
	// Update is called once per frame
	void Update () {
        // Photonに接続されていなければ起動しない
        if (!photonView.isMine)
        {
            return;
        }
	}

    public void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {

        }
    }
}
