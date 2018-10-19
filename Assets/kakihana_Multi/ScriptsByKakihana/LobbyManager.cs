using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class LobbyManager : Photon.MonoBehaviour {

    [SerializeField] GameMaster gm;

    // 左からプレイヤー人数、プレイヤー最大人数、ルーム作成者オブジェクト
    object playerNumObj, playerMaxNumObj, roomCreatorObj;

    public int playerNum;           // プレイヤー人数
    public int playerMaxNum;        // プレイヤー最大人数
    public string roomCreatorName;  // ルーム作成者

    [SerializeField]
    bool roomInfoFlg;               // ルームを更新するタイミングかどうか

    public Text playerNumText;      // 最大人数を表示させるテキスト

    public Text roomCreatorText;    // ルーム作成者を表示させるテキスト

    public Button readyButton;      // 準備完了ボタン
    public GameObject roomCustomButton; // ルーム設定表示用UI
    public GameObject roomCustomPanel;  // ルーム設定画面UI

    void Awake()
    {
        PhotonNetwork.automaticallySyncScene = true;
    }

	// Use this for initialization
	void Start () {
        Debug.Log("kenti"); // デバッグ用
        gm = this.gameObject.GetComponent<GameMaster>();
        Debug.Log(PhotonNetwork.masterClient);
        roomCustomPanel.SetActive(false);
        if (PhotonNetwork.playerName == PhotonNetwork.masterClient.NickName)
        {
            roomCustomButton.SetActive(true);
        }
        else
        {
            roomCustomButton.SetActive(false);
        }
        // 現在のプレイヤー人数を取得、一時オブジェクトに格納
        playerNumObj = PhotonNetwork.room.CustomProperties["RoomPlayerNum"];
        // ルーム作成者を取得、一時オブジェクトに格納
        roomCreatorObj = PhotonNetwork.room.CustomProperties["RoomCreator"];
        // プレイヤー人数オブジェクトよりint型にキャスト
        playerNum = (int)playerNumObj;
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

    void RoomInfoUpdate()
    {
        // 現在のプレイヤー人数を取得、一時オブジェクトに格納
        playerNumObj = PhotonNetwork.room.CustomProperties["RoomPlayerNum"];
        // ルーム作成者を取得、一時オブジェクトに格納
        roomCreatorObj = PhotonNetwork.room.CustomProperties["RoomCreator"];
        // プレイヤー人数オブジェクトよりint型にキャスト
        playerNum = (int)playerNumObj;
        // ルームの最大人数を取得
        playerMaxNum = PhotonNetwork.room.MaxPlayers;
        // ルーム作成者情報オブジェクトよりstring型にキャスト
        roomCreatorName = (string)roomCreatorObj;
        // UIに現在のルーム人数／最大人数を設定
        playerNumText.text = "ルーム人数：" + playerNum + " / " + playerMaxNum;
        // ルーム作成者情報をUIに設定
        roomCreatorText.text = "ルーム作成者：" + roomCreatorName;
    }

    public void RoomCustomWindow()
    {
        roomCustomPanel.SetActive(true);
    }

    public void ReadyOnClick()
    {
        gm.MultiPlayerEntry(PhotonNetwork.player.NickName, photonView.viewID);
        readyButton.interactable = false;
    }

    public void GetRoomInfo()
    {
    }

}
