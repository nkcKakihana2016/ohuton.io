using System.Collections;
using System.Collections.Generic;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine;

public class NerworkManager : Photon.MonoBehaviour {

    private string text = "";

    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings("v1.91");
    }

    void OnDestory()
    {
        // Photon切断
        PhotonNetwork.Disconnect();
    }

    void OnJoinedLobby()
    {
        // ランダムに入室（でもルームは１つのみ）
        PhotonNetwork.JoinRandomRoom();
    }

    void OnJoinedRoom()
    {
        Debug.Log("Room参加成功！");
        //プレイヤーをインスタンス化
        Vector3 spawnPosition = new Vector3(0.0f, 1.0f, 0.0f);
        var go = PhotonNetwork.Instantiate("Cube", spawnPosition, Quaternion.identity,0);
    }

    void OnPhotonRandomJoinFailed()
    {
        // ランダムに入室失敗した場合、ルームを作成
        // ルームオプションの作成
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.isVisible = true;
        roomOptions.isOpen = true;
        roomOptions.maxPlayers = 4;
        roomOptions.customRoomProperties = new Hashtable() { { "CustomProperties", "カスタムプロパティ" } };
        roomOptions.customRoomPropertiesForLobby = new string[] { "CustomProperties" };
        // ルームの作成
        PhotonNetwork.CreateRoom("CustomPropertiesRoom", roomOptions, null);
    }

    void OnGUI()
    {
        // ルームにいる場合のみ
        if (PhotonNetwork.inRoom)
        {
            // ルームの状態を取得
            Room room = PhotonNetwork.room;
            if (room == null)
            {
                return;
            }
            // ルームのカスタムプロパティを取得
            Hashtable cp = room.customProperties;
            GUILayout.Label((string)cp["CustomProperties"], GUILayout.Width(150));
            text = GUILayout.TextField(text, 100, GUILayout.Width(150));

            // カスタムプロパティを更新
            if (GUILayout.Button("更新"))
            {
                cp["CustomProperties"] = text;
                room.SetCustomProperties(cp);
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
