using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class NetworkLancher : Photon.MonoBehaviour {

    enum LancherState
    {
        TITLE,
        LOBBYIN,
        ROOMIN
    }

    string gameVersion = "v1.91"; // Photonのバージョン（一致していないと接続不可）

    LancherState lancherState;

    GameObject roomPrefab;
    public GameObject roomFailedDialog;

    // Photonに接続、タイトル画面のPlayボタンを押すと呼び出し
    public void Connect()
    {
        if (!PhotonNetwork.connected) // Photonに接続していなければ
        {
            PhotonNetwork.ConnectUsingSettings(gameVersion); // Photonに接続
            Debug.Log("Photon接続");
        }
    }

    // PUN SettingsのClient項目内にあるAuto-JoinedLobbyにチェックを入れると
    // Photon接続後、OnJoinedLobby（）が呼ばれる（デフォルトでON）
    public void OnJoinedLobby()
    {
        Debug.Log("ロビーに入りました");
        // ランダムでルームを選び入室する。
        // ルームがない場合はOnPhotonRandamJoinedFailed（）が呼ばれる
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnReceivedRoomListUpdate()
    {

    }

    // ルームが無い場合に呼ばれる
    public void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        roomFailedDialog.SetActive(true);
    }

    // ルームに入ると戦闘シーンに遷移
    public void OnJoinedRoom()
    {
        Debug.Log("ルームに入りました");
        PhotonNetwork.LoadLevel("LobbyStage");
    }


    // Use this for initialization
    void Start () {
        lancherState = LancherState.TITLE;
        roomFailedDialog.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        switch (lancherState)
        {
            case LancherState.TITLE:
                break;
            case LancherState.LOBBYIN:
                //RoomListUpdate();
                break;
            case LancherState.ROOMIN:
                break;
        }
	}

    public void RoomCreateClick()
    {
        // 作成する部屋の設定 // 
        RoomOptions roomOptions = new RoomOptions(); // RoomOptionの初期化
        roomOptions.IsVisible = true; // ルーム一覧に情報を表示させるかどうか
        roomOptions.IsOpen = true; // 他プレイヤーの入室を許可するか

        byte playerDefaultNum = 4; // 初期設定時のプレイヤー最大人数

        // 入室可能人数を設定 
        roomOptions.MaxPlayers = playerDefaultNum;

        // ロビーシーンで部屋作成者の名前を表示するために
        // ルームに作成者の名前を格納
        roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
        {
            {"RoomCreator",PhotonNetwork.playerName },
            {"RoomPlayerNum",PhotonNetwork.playerList.Length },
            {"RoomPlayerMaxNum",roomOptions.MaxPlayers}
        };

        //PhotonNetwork.room.SetCustomProperties();

        // ルーム一覧に作成した部屋情報を表示
        roomOptions.CustomRoomPropertiesForLobby = new string[]
        {
            "RoomCreator",
            "RoomPlayerNum",
            "RoomPlayerMaxNum"
        };

        // 部屋を作成
        PhotonNetwork.CreateRoom(PhotonNetwork.playerName, roomOptions, null);
    }
}

    //public void RoomListUpdate()
    //{
    //    if (PhotonNetwork.GetRoomList().Length == 0)
    //    {
    //        Debug.LogWarning("部屋がありません");
    //    }
    //    else
    //    {
    //        GameObject roomObj = null;
    //        foreach(RoomInfo room in PhotonNetwork.GetRoomList())
    //        {
    //            roomObj = Instantiate(roomPrefab) as GameObject;
    //            roomObj.transform.parent = GameObject.FindObjectOfType<Canvas>().GetComponent<Canvas>().transform;
    //            roomObj.transform.localScale = Vector3.one;
    //            roomObj.GetComponent<>
    //        }
    //    }
    //}
