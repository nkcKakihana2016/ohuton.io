using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkLancher : Photon.MonoBehaviour {

    string gameVersion = "v1.91"; // Photonのバージョン（一致していないと接続不可）

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

    // ルームが無い場合に呼ばれる
    public void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("ルームに入室出来ませんでした");
        PhotonNetwork.CreateRoom("TestRoom");
        Debug.Log("新しいルームを作成します");
    }

    // ルームに入ると戦闘シーンに遷移
    public void OnJoinedRoom()
    {
        Debug.Log("ルームに入りました");
        PhotonNetwork.LoadLevel("battle");
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
