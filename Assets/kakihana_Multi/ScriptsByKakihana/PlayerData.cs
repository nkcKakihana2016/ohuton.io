using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour{

    // 準備完了ステート
    public enum PlayerReady
    {
        ReadyOff = 0,
        ReadyOn
    }

    public PlayerReady isReady = PlayerReady.ReadyOff;

    // マスターが処理しやすいようにキャラクターデータをまとめたクラス

    Chara myChara;                  // キャラクタークラス
    GameMaster gm;                  // マスタークラス
    public PhotonView dataView;     // 自分のPhotonView
    public PhotonPlayer myPhotonPlayer;
    public GameObject mycharaObj;   // 自分のキャラクターオブジェクト
    public string playerName;       // 自分の名前
    public int viewID;              // 自分のPhotonViewID
    public int readyCount;          // 準備完了ボタンをクリックした回数を保存
    public int readyCountOld;       // 連投による誤動作を防止するために一時保存用変数を用意

    // 初期設定
    void Awake()
    {
        // ステートの設定
        isReady = PlayerReady.ReadyOff;
        // キャラクタークラスのコンポーネント取得
        myChara = this.gameObject.GetComponent<Chara>();
        // マスタークラスコンポーネントを取得
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        // 自分のキャラクターオブジェクトを格納
        mycharaObj = this.gameObject;
        // 自分の名前を格納
        playerName = myChara.myPhotonView.owner.NickName;
        // PhotonViewIDを格納
        viewID = myChara.myPhotonView.viewID;
        // PhotonViewを格納
        dataView = myChara.myPhotonView;
        myPhotonPlayer = PhotonPlayer.Find(myChara.myID);
        // 準備完了カウントの初期設定
        readyCount = 0;
        readyCountOld = readyCount;
    }

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        // 準備完了ボタンが押されたら１回実行される
        if (readyCount != readyCountOld)
        {
            if (readyCount % 2 == 1)
            {
                // 準備完了
                isReady = PlayerReady.ReadyOn;
            }
            else
            {
                // 準備完了キャンセル
                isReady = PlayerReady.ReadyOff;
            }
            // マスタークラスに準備完了状況を送信
            gm.ReadyCheck(viewID, (int)isReady);
            readyCountOld = readyCount;
        }
	}

    // 準備完了ボタンが押されたら
    public void ReadyOnClick()
    {
    }

    public void GetReady()
    {
        readyCount++;
    }
}
