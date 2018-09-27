using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerStatus : Photon.PunBehaviour,IPunObservable{

    // プレイヤー情報クラス

    public GameObject playerUIPrefab; // 使用するプレイヤー名UI

    public static GameObject localPlayer; // プレイヤーのローカルオブジェクト

    [SerializeField] GameObject statusUI;

    void Awake()
    {
        // Photonに接続されていれば
        if (photonView.isMine)
        {
            // ローカルオブジェクトに自身のオブジェクトを設定
            PlayerStatus.localPlayer = this.gameObject;
        }
    }

	// Use this for initialization
	void Start () {
        if (playerUIPrefab != null)
        {
            // プレイヤー名UIプレファブがアタッチされていたら生成する
            statusUI = Instantiate(playerUIPrefab) as GameObject;
            // PlayerNameUIスクリプト内にあるSetTarget()に情報を送信
            statusUI.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
        }
        else
        {

        }
	}
	
	// Update is called once per frame
	void Update () {
        // Photonに接続されていなければ起動しない
        if (!photonView.isMine)
        {
            return;
        }
	}

    public void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {

        }
    }
}
