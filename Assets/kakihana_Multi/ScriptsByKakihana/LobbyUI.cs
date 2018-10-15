using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class LobbyUI : MonoBehaviour {

    /* ロビーシーンにてルーム情報をプレイヤー全員に共有するクラス */
    /* 現状ルーム情報を共有できるのみ
       今後はルーム作成者のみルームのカスタマイズが可能で、変更後、
       プレイヤーにルーム情報変更を共有できるようにしたい
    */

    // CustomPropertiesキャスト用Object型変数
    // 何故かCustomPropertiesを直接キャスト出来ないため、一度object型にしている
    // 左からプレイヤー人数、プレイヤー最大人数、ルーム作成者オブジェクト
    object playerNumObj,playerMaxNumObj,roomCreatorObj;

    public int playerNum;           // プレイヤー人数
    public int playerMaxNum;        // プレイヤー最大人数
    public string roomCreatorName;  // ルーム作成者
    RoomInfo myRoominfo;            // ルーム情報

    public Text playerNumText;      // 最大人数を表示させるテキスト

    public Text roomCreatorText;    // ルーム作成者を表示させるテキスト

	// Use this for initialization
	void Start () {
        Debug.Log("kenti"); // デバッグ用
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

    // 使ってないコード群、使うかもしれないのでここに隔離
    #region
    /* Variable*/
    // 部屋作成ウィンドウ
    //public GameObject createRoomPanel;  // 部屋作成ウィンドウ
    //public Text roomNameText;           // 作成する部屋名
    //public Slider playerNumSlider;      // 最大人数を設定するSlider
    // 部屋作成ウィンドウ表示用ボタン
    //public Button openRoomPanelButton;
    //public GameObject roomCreatorPanel;
    //public GameObject roomPlayerNumPanel;
    //public Button createRoomButton;     // 部屋作成ボタン
    /*ルーム初期設定*/
    //void RoomInfoInit(RoomInfo roomInfo)
    //{
    //      roomInfo = PhotonNetwork.room;
    //      playerNum = (int)roomInfo.CustomProperties["RoomPlayerNum"];
    //      playerNumText.text = "ルーム人数：" + playerNum + " / " + roomInfo.CustomProperties["RoomPlayerMaxNum"];
    //      roomCreatorText.text = "ルーム作成者：" + (string)roomInfo.CustomProperties["RoomCreator"];
    //      Debug.Log(roomInfo.CustomProperties["RoomCreator"]);
    //      Debug.Log(roomInfo.CustomProperties["RoomPlayerMaxNum"]);
    //      Debug.Log(roomInfo.CustomProperties["RoomPlayerNum"]);
    //}

    /* Update()*/
    // playerNumSliderより、部屋人数をTextで表示
    //playerNumText.text = playerNumSlider.value.ToString();

    /* Start()*/
    //myRoominfo = PhotonNetwork.room;
    //playerMaxNumObj = PhotonNetwork.room.CustomProperties["RoomPlayerMaxNum"];
    // playerNumText.text = "ルーム人数：" + PhotonNetwork.room.CustomProperties["RoomPlayerNum"] + " / " +PhotonNetwork.room.CustomProperties["RoomPlayerMaxNum"];//"ルーム人数：" + playerNum + " / " + myRoominfo.CustomProperties["RoomPlayerMaxNum"];
    // roomCreatorText.text = string.Format("ルーム作成者：{0}", PhotonNetwork.room.CustomProperties["RoomCreator"]);
    //Debug.Log(myRoominfo.CustomProperties["RoomCreator"]);
    //Debug.Log(myRoominfo.CustomProperties["RoomPlayerMaxNum"]);
    //Debug.Log(myRoominfo.CustomProperties["RoomPlayerNum"]);
    //RoomInfoInit(myRoominfo);

    // 部屋新規作成ボタンが押されたときに実行される
    //public void OnClick_CreateRoomPanelButton()
    //{
    //    // 部屋作成ウィンドウが表示されていたら
    //    if (createRoomPanel.activeSelf)
    //    {
    //        createRoomPanel.SetActive(false); // 部屋作成ウィンドウ非表示
    //    }
    //    else
    //    {
    //        // そうでなければ部屋作成ウィンドウを表示
    //        createRoomPanel.SetActive(true);
    //    }
    //}

    //// 部屋作成ボタンを押したときに実行
    //public void OnClick_CreateRoomButton()
    //{
    //    // 作成する部屋の設定 // 
    //    RoomOptions roomOptions = new RoomOptions(); // RoomOptionの初期化
    //    roomOptions.IsVisible = true; // ルーム一覧に情報を表示させるかどうか
    //    roomOptions.IsOpen = true; // 他プレイヤーの入室を許可するか

    //    // 入室可能人数を設定 
    //    // RoomOptions.MaxPlayersがByte型なのでByte型にキャスト
    //    roomOptions.MaxPlayers = (byte)playerNumSlider.value;

    //    // ルーム一覧で部屋作成者の名前を表示するために
    //    // ルームに作成者の名前を格納
    //    roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
    //    {
    //        {"RoomCreator",PhotonNetwork.playerName }
    //    };

    //    // ルーム一覧に作成した部屋情報を表示
    //    roomOptions.CustomRoomPropertiesForLobby = new string[]
    //    {
    //        "RoomCreator",
    //    };

    //    // 部屋を作成
    //}

    //public void GetRoomInfo()
    //{
    //    foreach (var roominfo in PhotonNetwork.GetRoomList())
    //    {
    //        if (roominfo.CustomProperties.ContainsKey("RoomCreator"))
    //        {
    //            roomCreatorText.text = "ルーム作成者：" + (string)roominfo.CustomProperties["RoomCreator"];
    //            Debug.Log((string)roominfo.CustomProperties["RoomCreator"]);
    //        }
    //        if (roominfo.CustomProperties.ContainsKey("RoomPlayerNum"))
    //        {
    //            playerNum = (int)roominfo.CustomProperties["RoomPlayerNum"];
    //            Debug.Log((string)roominfo.CustomProperties["RoomPlayerNum"]);
    //        }
    //        if (roominfo.CustomProperties.ContainsKey("RoomPlayerMaxNum"))
    //        {
    //            roomCreatorText.text = "ルーム人数：" + playerNum + " / " + (string)roominfo.CustomProperties["RoomPlayerMaxNum"];
    //            Debug.Log((string)roominfo.CustomProperties["RoomPlayerMaxNum"]);
    //        }
    //    }
    //}

    #endregion

}
