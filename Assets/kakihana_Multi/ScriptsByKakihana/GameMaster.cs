using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : Photon.MonoBehaviour {

    // Photonでキャラクターを生成する際に使用するクラス
    // Photonでインスタンスする必要があるものはAssets/Resourcesフォルダ内に入れる

    public GameObject playerPrefab; // 使用するプレイヤープレファブ

    public MultiPlayerSettings multiSetting; // マルチプレイヤーのデータ情報
    public LobbyManager lobbyManager; // ロビー管理クラス
    public PhotonPlayer masterPlayer;

    public int maxPlayers; // 最大人数
    public int joinPlayers; // 参加人数
    public int playerCount = 0; // OnPhotonPlayerConnectedの呼び出し毎にカウントを足す

    public GameObject[] playerObj; // プレイヤーのオブジェクト
    public Chara[] playerList; // プレイヤーのコンポーネント
    public string[] playerNameList; // プレイヤー名
    public int[] viewIDList; // プレイヤーのPhotonViewID
    public bool[] roomMaster; // マスタークライアントかどうか

	// Use this for initialization
	void Start () {
        // Photonに接続されていなければ
        if (!PhotonNetwork.connected)
        {
            // エラーダイアログを表示させる、タイトルシーンへ戻る
            Debug.Log("エラーが発生しました。タイトルに戻ります");
            SceneManager.LoadScene("title");
            return;
        }
        else
        {
            // キャラクターを生成
            GameObject instancePlayer = PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity, 0);
            masterPlayer = PhotonNetwork.masterClient;
        }
        switch (SceneManager.GetActiveScene().name)
        {
            case "LobbyStage":
                multiSetting = GetComponent<MultiPlayerSettings>();
                maxPlayers = PhotonNetwork.room.MaxPlayers;
                // 各種管理したいプレイヤー情報の最大人数を設定
                #region
                playerObj = new GameObject[PhotonNetwork.room.MaxPlayers];
                playerList = new Chara[PhotonNetwork.room.MaxPlayers];
                playerNameList = new string[PhotonNetwork.room.MaxPlayers];
                viewIDList = new int[PhotonNetwork.room.MaxPlayers];
                roomMaster = new bool[PhotonNetwork.room.MaxPlayers];
                #endregion
                if (masterPlayer == PhotonNetwork.masterClient)
                {
                    playerNameList[playerCount] = masterPlayer.NickName;
                    playerCount++;
                }
                //// キャラクターを生成
                //GameObject instancePlayer = PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity, 0);
                break;
            case "battle":
                break;
        }
        // 正常に接続されていればキャラクターを生成させる
	}
	
	// Update is called once per frame
	void Update () {
	}

    // プレイヤーがロビーシーンに参加したときに呼ばれる
    public void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        // 〇〇さんがログインしました
        Debug.Log(player.NickName + " is joined.");
        // デバッグ用、マスタークライアントを表示
        Debug.Log(PhotonNetwork.masterClient.NickName);
        // 後から接続してきたプレイヤー名を取得、リストに格納
        playerNameList[playerCount] = player.NickName;
        // カウントを足す
        playerCount++;
        // ルーム情報更新 // RoomInfoUpdate()はLobbyManagerの[PunRPC]下にある
        photonView.RPC("RoomInfoUpdate", PhotonTargets.All);
        UpdateMemberList();
    }

    // プレイヤーが退室したとき呼び出される
    public void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        // 〇〇さんがログアウトしました
        Debug.Log(player.NickName + " is disconnected");
        // ルーム情報更新
        photonView.RPC("RoomInfoUpdate", PhotonTargets.All);
    }

    void UpdateMemberList()
    {

    }

    public void Ready(int viewID)
    {

    }

    void MasterLobbyMode()
    {

    }

    // プレイヤーの情報をもとに管理リストに代入
    public void MultiPlayerEntry(string playerName,int viewID)
    {
        switch (viewID /= 1000)
        {
            case 1:
                playerNameList[0] = playerName;
                viewIDList[0] = viewID;
                roomMaster[0] = true;
                break;
            case 2:
                playerNameList[1] = playerName;
                viewIDList[1] = viewID;
                roomMaster[1] = false;
                break;
            case 3:
                playerNameList[2] = playerName;
                viewIDList[2] = viewID;
                roomMaster[2] = false;
                break;
            case 4:
                playerNameList[3] = playerName;
                viewIDList[3] = viewID;
                roomMaster[3] = false;
                break;
            case 5:
                playerNameList[4] = playerName;
                viewIDList[4] = viewID;
                roomMaster[4] = false;
                break;
            case 6:
                playerNameList[5] = playerName;
                viewIDList[5] = viewID;
                roomMaster[5] = false;
                break;
        }
    }

    // データの同期は[PunRPC]以下のメソッドで行う
    [PunRPC]
    void Sample()
    {

    }
}
