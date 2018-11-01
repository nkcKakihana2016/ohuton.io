using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class LobbyManager : Photon.MonoBehaviour {

    [SerializeField] GameMaster gm; // ゲームマスターコンポーネント

    // ルーム作成者オブジェクト
    object roomCreatorObj;

    public int playerNum;           // プレイヤー人数
    public int playerMaxNum;        // プレイヤー最大人数
    public string roomCreatorName;  // ルーム作成者

    public Text playerNumText;      // 最大人数を表示させるテキスト

    public Text roomCreatorText;    // ルーム作成者を表示させるテキスト
    public Text roomPlayerNumText;  // スライダーで人数を表示させるためのテキスト

    public Slider playerNumSlider;  // ルーム人数変更スライダー

    public Button readyButton;      // 準備完了ボタン
    public GameObject roomCustomButton; // ルーム設定表示用UI
    public GameObject roomCustomPanel;  // ルーム設定画面UI
    public GameObject roomLeavePanel;   // 部屋退出ダイアログUI

    void Awake()
    {
        // マスタークライアントのsceneと同じsceneを部屋に入室した人もロードする。
        PhotonNetwork.automaticallySyncScene = true;
    }

	// Use this for initialization
	void Start () {
        Debug.Log("kenti"); // デバッグ用
        gm = this.gameObject.GetComponent<GameMaster>(); // ゲームマスターコンポーネント取得
        Debug.Log(PhotonNetwork.masterClient); // マスタークライアント表示（デバッグ用）
        roomCustomPanel.SetActive(false);      // ルーム設定画面一時非表示
        readyButton.enabled = false;           // ボタン表示一時非表示
        roomLeavePanel.SetActive(false);
        // 自分がマスタークライアントだったら
        if (PhotonNetwork.playerName == PhotonNetwork.masterClient.NickName)
        {
            // ルーム設定ボタンを表示
            roomCustomButton.SetActive(true);
            // 準備完了ボタンを表示
            readyButton.enabled = true;
        }
        else
        {
            // マスタークライアントでなければ表示しない
            roomCustomButton.SetActive(false);
            readyButton.enabled = false;
        }
        // ルーム作成者を取得、一時オブジェクトに格納
        roomCreatorObj = PhotonNetwork.room.CustomProperties["RoomCreator"];
        // プレイヤー人数を取得
        playerNum = PhotonNetwork.room.PlayerCount;
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
        // マスタークライアントだったら
        if (PhotonNetwork.player == PhotonNetwork.masterClient)
        {
            // ルーム設定画面が表示されているか
            if (roomCustomPanel.GetActive() == true)
            {
                // 表示されていたらスライダーのゲージに応じて人数を可視化
                roomPlayerNumText.text = playerNumSlider.value.ToString();
            }
        }
	}

    // ルーム設定画面を表示
    public void RoomCustomWindow()
    {
        roomCustomPanel.SetActive(true);
    }

    // ルーム設定画面の「設定を更新」ボタンが押されたときに呼び出される
    public void RoomCustomChange()
    {
        // ルーム最大人数を更新
        // ただしスライダーの値と現在のルーム設定が一致していたら更新しない
        if (PhotonNetwork.room.MaxPlayers != (int)playerNumSlider.value)
        {
            // プレイヤー最大人数を更新
            PhotonNetwork.room.MaxPlayers = (int)playerNumSlider.value;
            // ルーム情報の同期
            photonView.RPC("RoomInfoUpdate", PhotonTargets.All);
            Debug.Log("kentinotchange");
        }
        // ルーム設定画面を非表示
        roomCustomPanel.SetActive(false);
        Debug.LogFormat("人数変更{0}", PhotonNetwork.room.MaxPlayers);
    }

    // 準備完了ボタンが押されたら
    public void ReadyOnClick()
    {
        // カウントダウン準備
        gm.CountDownStart();
        // ボタンが押せないようにする
        readyButton.interactable = false;
    }

    // 部屋退出ボタンが押されたら
    public void LeaveRoomButtonClick()
    {
        // 退出確認ダイアログ表示
        roomLeavePanel.SetActive(true);
    }

    // 退出確認ダイアログで「はい」が押された場合
    public void LeaveRoom()
    {
        Debug.Log("Logout");
        // 退出確認ダイアログ非表示
        roomLeavePanel.SetActive(false);
        // Photon切断
        PhotonNetwork.Disconnect();
        // タイトル画面に戻る
        SceneManager.LoadScene("title");
    }
    // 退出確認ダイアログで「いいえ」が押されたとき
    public void ReturnGame()
    {
        // ゲームに戻る
        roomLeavePanel.SetActive(false);
    }
    // カウントダウンコルーチン
    IEnumerator CountDownTimer()
    {
        Debug.Log("3");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("2");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("1");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("GO!");
        yield return new WaitForSeconds(1.0f);
        // ここでロビーに居る全プレイヤーが戦闘用シーンに移動
        photonView.RPC("MoveToBattleScene", PhotonTargets.All);
    }

    [PunRPC]
    // RPCで全クライアントに現在の参加人数を同期
    public void RoomInfoUpdate()
    {
        Debug.Log("kentiroominfo");
        // プレイヤー人数を更新
        playerNum = PhotonNetwork.room.PlayerCount;
        // UIに現在のルーム人数／最大人数を設定
        playerNumText.text = "ルーム人数：" + playerNum + " / " + PhotonNetwork.room.MaxPlayers;
        Debug.Log(PhotonNetwork.masterClient.NickName);
    }
    // コルーチンが直接RPCに入れても動作しないためメソッドを経由してコルーチンを起動
    [PunRPC]
    public void CountDown()
    {
        StartCoroutine(CountDownTimer());
    }

}
