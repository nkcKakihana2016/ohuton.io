using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : Photon.MonoBehaviour {

    // ロビーシーン内のプレイヤーの準備状況をアイコンで動的に動かすクラス

    // アイコンを切り替えるステート
    public enum IconState
    {
        yourPlayer = 0, // 自分を識別するためのアイコン（他のプレイヤーには見えない）
        readyOK,        // 準備完了
        notReady        // 準備していない
    }

    public GameMaster gm;               // マスタークラス
    public LobbyManager lobbyManager;   // ロビークラス
    public PlayerData myData;           // 参照するキャラクター情報
    public PhotonView iconView;         // 参照するPhotonView

    // アイコンステートの初期化
    public IconState myIconState = IconState.notReady;

    // UIとして反映させるための変数
    public Image iconImage;
    // アイコンの種類
    public Sprite[] icon = new Sprite[3];

    public int ownerID;                 // 参照するPhotonViewID
    public string ownerName;            // プレイヤー名

    

	// Use this for initialization
	void Start () {
        // マスタークラスコンポーネント取得
        gm = GameObject.FindObjectOfType<GameMaster>().GetComponent<GameMaster>();
        // ロビークラスコンポーネント取得
        lobbyManager = GameObject.FindObjectOfType<GameMaster>().GetComponent<LobbyManager>();
        // IDに応じてアイコンの表示位置を設定
        switch (ownerID / 1000)
        {
            case 1:
                this.GetComponent<Transform>().SetParent(lobbyManager.playerStatusIcon[(ownerID / 1000) - 1].GetComponent<Transform>());
                this.transform.position = lobbyManager.playerStatusIcon[(ownerID / 1000)-1].transform.position;
                break;
            case 2:
                this.GetComponent<Transform>().SetParent(lobbyManager.playerStatusIcon[(ownerID / 1000) - 1].GetComponent<Transform>());
                this.transform.position = lobbyManager.playerStatusIcon[(ownerID / 1000) - 1].transform.position;
                break;
            case 3:
                this.GetComponent<Transform>().SetParent(lobbyManager.playerStatusIcon[(ownerID / 1000) - 1].GetComponent<Transform>());
                this.transform.position = lobbyManager.playerStatusIcon[(ownerID / 1000) - 1].transform.position;
                break;
            case 4:
                this.GetComponent<Transform>().SetParent(lobbyManager.playerStatusIcon[(ownerID / 1000) - 1].GetComponent<Transform>());
                this.transform.position = lobbyManager.playerStatusIcon[(ownerID / 1000) - 1].transform.position;
                break;
            case 5:
                this.GetComponent<Transform>().SetParent(lobbyManager.playerStatusIcon[(ownerID / 1000) - 1].GetComponent<Transform>());
                this.transform.position = lobbyManager.playerStatusIcon[(ownerID / 1000) - 1].transform.position;
                break;
            case 6:
                this.GetComponent<Transform>().SetParent(lobbyManager.playerStatusIcon[(ownerID / 1000) - 1].GetComponent<Transform>());
                this.transform.position = lobbyManager.playerStatusIcon[(ownerID / 1000) - 1].transform.position;
                break;
        }
        // imageコンポーネント取得
        iconImage = this.gameObject.GetComponent<Image>();
        // 参照しているキャラクターデータクラスとこのクラスに設定されているIDと一致しているか
        if (myData.viewID == ownerID)
        {
            // 一致していたら識別アイコンに設定
            iconImage.sprite = icon[(int)IconState.yourPlayer];
        }
        else
        {
            // 一致していなければ準備未完了アイコンに設定
            iconImage.sprite = icon[(int)IconState.notReady];
        }
        // キャラクターUI同期（自分以外のプレイヤーに影響）
        photonView.RPC("ShowImage", PhotonTargets.Others);
    }
	
	// Update is called once per frame
	void Update () {
        // 準備完了ボタンが押されたら
        if(myData.isReady == PlayerData.PlayerReady.ReadyOn)
        {
            // アイコンを変える
            IconChange();
        }
	}

    // アイコンクラスとキャラクターデータを関連付けるメソッド
    public void IconDataInit(PlayerData data)
    {
        // キャラクターデータクラスのコンポーネント取得
        myData = data.GetComponent<PlayerData>();
        // キャラクターデータクラスよりViewIDを取得
        ownerID = myData.viewID;
        // プレイヤー名を設定
        ownerName = myData.playerName;
        // PhotonViewを設定
        this.iconView = PhotonView.Get(data.mycharaObj);
    }

    // アイコンを変えるメソッド
    [PunRPC]
    public void IconChange()
    {
        // 表示させるアイコンを設定
        iconImage.sprite = icon[(int)IconState.readyOK];
    }

    // アイコン表示初期設定メソッド
    [PunRPC]
    public void ShowImage()
    {
        iconImage.sprite = icon[(int)IconState.notReady];
    }
}
