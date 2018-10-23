using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class LobbyManager : Photon.MonoBehaviour {

    [SerializeField] GameMaster gm; // ゲームマスターコンポーネント

    // ルーム作成者オブジェクト
    object roomCreatorObj;

    public int playerNum;           // プレイヤー人数
    public int playerMaxNum;        // プレイヤー最大人数
    public string roomCreatorName;  // ルーム作成者

    public Text playerNumText;      // 最大人数を表示させるテキスト

    public Text roomCreatorText;    // ルーム作成者を表示させるテキスト

    public Button readyButton;      // 準備完了ボタン
    public GameObject roomCustomButton; // ルーム設定表示用UI
    public GameObject roomCustomPanel;  // ルーム設定画面UI

    void Awake()
    {
        // マスタークライアントのsceneと同じsceneを部屋に入室した人もロードする。
        PhotonNetwork.automaticallySyncScene = true;
    }

	// Use this for initialization
	void Start () {
        Debug.Log("kenti"); // デバッグ用
        gm = this.gameObject.GetComponent<GameMaster>(); // ゲームマスターコンポーネント取得
        Debug.Log(PhotonNetwork.masterClient); // マスタークライアント表示（デバッグ用）
        roomCustomPanel.SetActive(false); // ルーム設定画面一時非表示
        // 自分がマスタークライアントだったら
        if (PhotonNetwork.playerName == PhotonNetwork.masterClient.NickName)
        {
            // ルーム設定ボタンを表示
            roomCustomButton.SetActive(true);
        }
        else
        {
            // マスタークライアントでなければ表示しない
            roomCustomButton.SetActive(false);
        }
        // ルーム作成者を取得、一時オブジェクトに格納
        roomCreatorObj = PhotonNetwork.room.CustomProperties["RoomCreator"];
        // プレイヤー人数を取得
        playerNum = PhotonNetwork.room.PlayerCount;
        // ルームの最大人数を取得
        playerMaxNum = PhotonNetwork.room.MaxPlayers;
        // ルーム作成者情報オブジェクトよりstring型にキャスト
        roomCreatorName = (string)roomCreatorObj;
        // UIに現在のルーム人数／最大人数を設定
        playerNumText.text = "ルーム人数：" + playerNum + " / " + playerMaxNum;
        // ルーム作成者情報をUIに設定
        roomCreatorText.text = "ルーム作成者：" + roomCreatorName;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    // ルーム設定画面を表示
    public void RoomCustomWindow()
    {
        roomCustomPanel.SetActive(true);
    }

    // 準備完了ボタンが押されたら
    public void ReadyOnClick()
    {
        // ボタンが押せないようにする
        readyButton.interactable = false;
    }

    public void GetRoomInfo()
    {
    }

    [PunRPC]
    // RPCで全クライアントに現在の参加人数を同期
    public void RoomInfoUpdate()
    {
        Debug.Log("kentiroominfo");
        // プレイヤー人数を更新
        playerNum = PhotonNetwork.room.PlayerCount;
        // UIに現在のルーム人数／最大人数を設定
        playerNumText.text = "ルーム人数：" + playerNum + " / " + playerMaxNum;
    }

}
