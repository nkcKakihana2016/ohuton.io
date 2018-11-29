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
    public GameObject mycharaObj;   // 自分のキャラクターオブジェクト
    public string playerName;       // 自分の名前
    public int viewID;              // 自分のPhotonViewID

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
    }

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // 準備完了ボタンが押されたら
    public void ReadyOnClick()
    {
        // 準備完了ステート変更
        isReady = PlayerReady.ReadyOn;
    }
}
