using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;
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
    public int readyCount = 0;      // 準備完了状態の人数
    public int countDownTimer = 3;  // カウントダウンの秒数

    [SerializeField]
    public List<string> playerNameList;   // プレイヤー名リスト
    public List<int> idList;              // IDリスト（仮）
    public List<bool> playerReady;        // 各プレイヤーの準備完了状況
    public List<PlayerData> playerDataList; // プレイヤーデータリスト

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
                    // このスクリプトをマスタークライアントに処理させる
                    masterPhotonView.TransferOwnership(masterPlayer);
                    // プレイヤーリストに名前を追加
                    playerNameList.Add(masterPlayer.NickName);
                    // 参加人数を足す
                    playerCount++;
                    // 準備完了状況の初期化
                    masterPhotonView.RPC("ReadyCountUpdate", PhotonTargets.AllBuffered, readyCount);
                }
                // 最大人数を取得
                maxPlayers = PhotonNetwork.room.MaxPlayers;
                break;
            case "battle":
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        // 全員が準備完了ボタンを押したらゲームスタート
        if (readyCount == PhotonNetwork.room.MaxPlayers)
        {
            CountDownStart();
        }
	}

    // プレイヤーがロビーシーンに参加したときに呼ばれる
    public void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        // 〇〇さんがログインしました
        Debug.Log(player.NickName + " is joined.");
        // デバッグ用、マスタークライアントを表示
        Debug.Log(PhotonNetwork.masterClient.NickName);
        // 後から接続してきたプレイヤー名を取得、リストに格納
        playerNameList.Add(player.NickName);
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
        // プレイヤーリストから除外
        playerNameList.Remove(player.NickName);
        // IDリストから除外
        idList.Remove(player.ID);
        // プレイヤーデータリストから名前が一致した要素を除外
        for (int i = 0; i < playerDataList.Count; i++)
        {
            if (player.NickName == playerDataList[i].playerName)
            {
                playerDataList.Remove(playerDataList[i]);
            }
        }
        // ルーム情報更新
        photonView.RPC("RoomInfoUpdate", PhotonTargets.All,readyCount);
    }

    // 準備完了処理
    public void ReadyCheck(int ID,int readyState)
    {
        Debug.LogFormat("ID：{0} ,StateNo：{1}", ID, readyState);
        // IDリストを並び替える
        idList.Sort();
        // IDリストより送られてきたIDで検索しインデックスを取得
        int index = idList.IndexOf(ID);
        Debug.LogFormat("Index:{0}", index);
        // 送られてきたViewIDがゲームプレイヤーリストにあるか調べる
        if (idList.Contains(ID))
        {
            // マスター側とクライアント側の準備完了状況をチェック
            if (playerReady[index] == false && readyState == 1)
            {
                // 準備完了の場合の処理 ReadyCount();メソッドへ
                photonView.RPC("ReadyCount",PhotonTargets.AllBuffered,index);
                Debug.Log("ReadyCount【ADD】");
            }
            else if(playerReady[index] == true && readyState == 0)
            {
                // 準備完了がキャンセルされたときの処理 ReadyDiv();メソッドへ
                photonView.RPC("ReadyDiv", PhotonTargets.AllBuffered, index);
                Debug.Log("ReadyCount【DIV】");
            }
        }
    }

    [PunRPC]
    // 準備完了をカウントするメソッド
    public void ReadyCount(int index)
    {
        Debug.Log(index);
        // カウントを足す
        readyCount++;
        // マスター側の準備完了状況を更新
        playerReady[index] = true;
        // 準備完了UIを更新
        photonView.RPC("ReadyCountUpdate", PhotonTargets.AllBuffered, readyCount);
    }


    [PunRPC]
    // 準備完了を取り消すメソッド
    public void ReadyDiv(int index)
    {
        // カウントを引く
        readyCount--;
        // マスター側の準備完了状況を更新
        playerReady[index] = false;
        // 準備完了UIを更新
        photonView.RPC("ReadyCountUpdate", PhotonTargets.AllBuffered, readyCount);
    }

    // 準備完了状況の初期設定
    public void IsReadyInit(int viewID)
    {
        // IDリストよりインデックスを取得
        int idIndex = idList.IndexOf(viewID);
        Debug.LogFormat("IndexOfID：{0}", idIndex);
        // 準備完了状況リストに追加
        playerReady.Insert(idIndex, false);
    }

    // カウントダウンをスタートさせる
    public void CountDownStart()
    {
        // カウントダウンの同期
        photonView.RPC("CountDown", PhotonTargets.All);
    }

    // データの同期は[PunRPC]以下のメソッドで行う
    [PunRPC]
    void Sample()
    {
        // サンプル用
    }

    // 戦闘用シーンに移行するためのメソッド
    [PunRPC]
    public void MoveToBattleScene()
    {
        PhotonNetwork.LoadLevel("battle");
    }
}
