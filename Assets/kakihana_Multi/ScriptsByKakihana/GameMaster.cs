using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : Photon.MonoBehaviour {

    // Photonでキャラクターを生成する際に使用するクラス
    // Photonでインスタンスする必要があるものはAssets/Resourcesフォルダ内に入れる

    public GameObject playerPrefab; // 使用するプレイヤープレファブ

    public MultiPlayerSettings multiSetting; // マルチプレイヤーのデータ情報
    public LobbyManager lobbyManager;        // ロビー管理クラス
    public PhotonView masterPhotonView;      // マスタークライアント用PhotonView
    public PhotonPlayer masterPlayer;        // マスタークライアントのPhotonPlayer情報

    public int maxPlayers;          // 最大人数
    public int joinPlayers;         // 参加人数
    public int playerCount = 0;     // OnPhotonPlayerConnectedの呼び出し毎にカウントを足す
    public int readyCount = 0;      // 準備完了ボタンを押した人数を保存
    public int countDownTimer = 3;  // カウントダウンの秒数

    public string[] playerNameList; // プレイヤー名
    public int[] viewIDList;        // プレイヤーのPhotonViewID

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
            // マスタークライアントを取得する
            masterPlayer = PhotonNetwork.masterClient;
        }
        // ゲームシーン名を取得し、シーンに応じた処理を行う
        switch (SceneManager.GetActiveScene().name)
        {
            // ロビーシーンの場合の処理
            case "LobbyStage":
                // 取得したマスタークライアントが一致していたら
                if (masterPlayer == PhotonNetwork.masterClient)
                {
                    playerNameList = new string[PhotonNetwork.room.MaxPlayers];
                    viewIDList = new int[PhotonNetwork.room.MaxPlayers];
                    // このスクリプトをマスタークライアントがメインで操作するようにする
                    masterPhotonView.TransferOwnership(masterPlayer);
                    // プレイヤーリストに名前を追加
                    playerNameList[playerCount] = masterPlayer.NickName;
                    // 参加人数を足す
                    playerCount++;
                }
                multiSetting = GetComponent<MultiPlayerSettings>();
                maxPlayers = PhotonNetwork.room.MaxPlayers;
                break;
            case "battle":
                break;
        }
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
    }

    // プレイヤーが退室したとき呼び出される
    public void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        // 〇〇さんがログアウトしました
        Debug.Log(player.NickName + " is disconnected");
        // ルーム情報更新
        photonView.RPC("RoomInfoUpdate", PhotonTargets.All);
    }

    // カウントダウンをスタートさせる
    public void CountDownStart()
    {
        photonView.RPC("CountDown", PhotonTargets.All);
    }

    // データの同期は[PunRPC]以下のメソッドで行う
    [PunRPC]
    void Sample()
    {

    }

    // 戦闘用シーンに移行するためのメソッド
    [PunRPC]
    public void MoveToBattleScene()
    {
        PhotonNetwork.LoadLevel("battle");
    }
}
