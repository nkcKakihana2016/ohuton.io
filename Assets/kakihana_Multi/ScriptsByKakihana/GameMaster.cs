using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : Photon.MonoBehaviour {

    public enum SceneMode
    {
        TITLE,
        LOBBY,
        BATTLE
    }

    // Photonでキャラクターを生成する際に使用するクラス
    // Photonでインスタンスする必要があるものはAssets/Resourcesフォルダ内に入れる

    public GameObject playerPrefab; // 使用するプレイヤープレファブ
    SceneMode sceneMode;

	// Use this for initialization
	void Start () {
        // Photonに接続されていなければ
        if (!PhotonNetwork.connected)
        {
            // エラーダイアログを表示させる、タイトルシーンへ戻る
            Debug.Log("エラーが発生しました。タイトルに戻ります");
            SceneManager.LoadScene("title");
            sceneMode = SceneMode.TITLE;
            return;
        }
        switch (SceneManager.GetActiveScene().name)
        {
            case "LobbyStage":
                GameObject player = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity, 0);
                sceneMode = SceneMode.LOBBY;
                break;
            case "battle":
                break;
        }
        // 正常に接続されていればキャラクターを生成させる
	}
	
	// Update is called once per frame
	void Update () {
        switch (sceneMode)
        {
            case SceneMode.LOBBY:
                MasterLobbyMode();
                break;
        }
	}

    public void OnPhotonPlayerConnected(PhotonPlayer player)
    {

    }

    public void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {

    }

    void MasterLobbyMode()
    {

    }
}
