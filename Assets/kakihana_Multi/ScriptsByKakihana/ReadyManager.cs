using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ReadyManager : MonoBehaviour {

    // 準備完了ボタンを管理するクラス

    LobbyManager lobbyManager;     // ロビークラス
    Transform btnPos;              // ボタンを表示させる座標
    Button btn;                    // ボタンのコンポーネント

    public PlayerData myData;      // プレイヤーのデータ
    public GameMaster gm;          // マスタークラス
    public int cnt = 0;            // クリック毎にカウント

    // Use this for initialization
    void Start()
    {
        // ゲームマスターコンポーネント取得
        gm = GameObject.FindObjectOfType<GameMaster>().GetComponent<GameMaster>();
        // ロビークラスコンポーネント取得
        lobbyManager = GameObject.FindObjectOfType<GameMaster>().GetComponent<LobbyManager>();
        // 準備完了ボタンコンポーネント取得
        btn = this.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // このクラスとキャラクター情報を関連付けするメソッド
    public void dataInit(PlayerData data)
    {
        // データを関連付ける
        myData = data;
        myData.GetComponent<PlayerData>();
    }

    // ボタンがクリックされたら
    public void ReadyClick()
    {
        myData.GetReady();
    }
}
