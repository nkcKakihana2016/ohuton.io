using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class LobbyManager : Photon.MonoBehaviour {

    public enum DialogMessage
    {
        ChangeMaster = 0,
        RoomStatusUpdate
    }

    [SerializeField] GameMaster gm; // ゲームマスターコンポーネント

    // ルーム作成者オブジェクト
    object roomCreatorObj;

    public int playerNum;           // プレイヤー人数
    public int playerMaxNum;        // プレイヤー最大人数
    public string roomCreatorName;  // ルーム作成者
    public int readyCountNum = 0;
    int readyButtonCnt = 0;

    public Text playerNumText;      // 最大人数を表示させるテキスト

    public Text roomCreatorText;    // ルーム作成者を表示させるテキスト
    public Text roomPlayerNumText;  // スライダーで人数を表示させるためのテキスト
    public Text readyPlayerNumText; // 準備完了カウントテキスト
    public Text[] dialogMessageList;    // ダイアログに出力するメッセージ一覧
    public Text dialogMessage;

    public Slider playerNumSlider;  // ルーム人数変更スライダー

    //public GameObject readyButtonObj;   // 準備完了ボタン
    //[SerializeField] Button readyButton;
    public GameObject roomCustomButton; // ルーム設定表示用UI
    public GameObject roomCustomPanel;  // ルーム設定画面UI
    public GameObject roomLeavePanel;   // 部屋退出ダイアログUI
    public GameObject dialogPanel;      // ダイアログUI

    public GameObject readyBtnTransObj; // 準備完了ボタンのオブジェクト

    public GameObject[] playerStatusIcon = new GameObject[6]; // プレイヤー情報アイコン

    void Awake()
    {
        // マスタークライアントのsceneと同じsceneを部屋に入室した人もロードする。
        PhotonNetwork.automaticallySyncScene = true;
    }

    // Use this for initialization
    void Start() {
        gm = this.gameObject.GetComponent<GameMaster>(); // ゲームマスターコンポーネント取得
        roomCustomPanel.SetActive(false);      // ルーム設定画面一時非表示
        roomLeavePanel.SetActive(false);       // ルーム退場画面一時非表示
        dialogPanel.SetActive(false);
        // 自分がマスタークライアントだったら
        if (PhotonNetwork.playerName == PhotonNetwork.masterClient.NickName)
        {
            // このスクリプトをマスタークライアントが処理する
            gm.masterPhotonView.TransferOwnership(gm.masterPlayer);
            // ルーム設定ボタンを表示
            roomCustomButton.SetActive(true);
            photonView.RPC("ShowLobbyInfo", PhotonTargets.All);
            // 準備完了状況を表示
            photonView.RPC("ReadyCountUpdate", PhotonTargets.All, readyCountNum);
        }
        else
        {
            // マスタークライアントでなければ表示しない
            roomCustomButton.SetActive(false);
        }
        // プレイヤー人数を取得
        playerNum = PhotonNetwork.room.PlayerCount;
        // ルームの最大人数を取得
        playerMaxNum = PhotonNetwork.room.MaxPlayers;
        // UIに現在のルーム人数／最大人数を設定
        playerNumText.text = playerNum + " / " + playerMaxNum;
        if (this.photonView.isMine)
        {

        }
        if (PhotonNetwork.player.ID - 1 == gm.playerNameList.IndexOf(this.photonView.owner.NickName))
        {
            Debug.Log("SuccessID");
        }
        else
        {
            Debug.Log("NotSuccessID");
        }
        Debug.Log(PhotonNetwork.masterClient); // マスタークライアント表示（デバッグ用）
    }

    // Update is called once per frame
    void Update() {
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
            //photonView.RPC("ShowDialog", PhotonTargets.All, DialogMessage.RoomStatusUpdate);
        }
        // ルーム設定画面を非表示
        roomCustomPanel.SetActive(false);
        Debug.LogFormat("人数変更{0}", PhotonNetwork.room.MaxPlayers);
    }

    // 準備完了ボタンが押されたら
    public void ReadyOnClicked()
    {
        // カウントダウン準備
        //gm.CountDownStart();
        // ボタンが押せないようにする
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

    public void OK_ButtonClick()
    {
        dialogPanel.SetActive(false);
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
        playerNumText.text = playerNum + " / " + PhotonNetwork.room.MaxPlayers;
        Debug.Log(PhotonNetwork.masterClient.NickName);
    }
    // コルーチンが直接RPCに入れても動作しないためメソッドを経由してコルーチンを起動
    [PunRPC]
    public void CountDown()
    {
        StartCoroutine(CountDownTimer());
    }

    [PunRPC]
    public void ShowLobbyInfo()
    {
        for (int i = 0; i < gm.maxPlayers; i++)
        {

        }
    }

    // 準備完了状況を更新する
    [PunRPC]
    public void ReadyCountUpdate(int count)
    {
        readyPlayerNumText.text = count + "/" + PhotonNetwork.room.MaxPlayers;
    }
    // 各種エラーやダイアログなどはこのメソッドで管理する予定
    //public void ShowDialog(DialogMessage message)
    //{
    //    Debug.Log(message);
    //    switch (message)
    //    {
    //        case DialogMessage.ChangeMaster:
    //            dialogMessage = this.GetComponent<Text>();
    //            dialogMessageList[(int)message].GetComponent<Text>();
    //            dialogMessage.text += dialogMessageList[(int)message].text;
    //            dialogPanel.SetActive(true);
    //            break;
    //        case DialogMessage.RoomStatusUpdate:
    //            dialogMessage = this.GetComponent<Text>();
    //            dialogMessageList[(int)message].GetComponent<Text>();
    //            dialogMessage.text += dialogMessageList[(int)message].text;
    //            Debug.Log("kentiUpdate");
    //            dialogPanel.SetActive(true);
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
