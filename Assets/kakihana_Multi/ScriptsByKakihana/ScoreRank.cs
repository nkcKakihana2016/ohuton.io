using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRank : MonoBehaviour {

    // 参照するプレイヤーリスト
    public enum WatchPlayer
    {
        Player1 = 1,
        Player2,
        Player3,
        Player4
    }

    [SerializeField] LobbyManager lm;               // ロビークラス
    [SerializeField] RankCalc rankCalc;             // 順位表示完了クラス
    public GameObject watchPlayerObj;               // 参照するプレイヤーオブジェクト
    public Jyroball playerInfo;                     // 参照するプレイヤースクリプト

    public WatchPlayer watchPlayer;                 // インスペクター上でどのプレイヤーを参照するか設定する
    [SerializeField] Image myRankImage;             // 順位を表示させるためのUI
    [SerializeField] Image readyImage;
    public int rank;                                // 現在の順位
    public int oldRank = 0;                         // UI連続切り替え防止用、一時保存順位
    public Sprite[] imageSouces = new Sprite[4];    // 各順位の画像を格納する変数
    public Sprite readyOkImage;
    // Use this for initialization
    void Start () {
        // ロビークラスコンポーネント取得
        lm = GameObject.FindObjectOfType<LobbyManager>().GetComponent<LobbyManager>();
        // 参照プレイヤーリストをもとにプレイヤーオブジェクトを取得
        watchPlayerObj = GameObject.Find(string.Format("Player{0}", (int)watchPlayer));
        // 参照プレイヤーオブジェクトよりプレイヤーコンポーネント取得
        playerInfo = watchPlayerObj.GetComponent<Jyroball>();
        // 順位計算クラスのコンポーネント取得
        rankCalc = GameObject.FindObjectOfType<RankCalc>().GetComponent<RankCalc>();
        // 順位計算クラスにスコア情報を登録
        rankCalc.ScoreEntry(this);
        // 順位UIの初期設定
        myRankImage.sprite = imageSouces[rank];
    }
	
	// Update is called once per frame
	void Update () {
        if (lm.sceneMode == LobbyManager.SceneMode.Lobby)
        {
            // ロビーの場合は順位UIを表示しない
            myRankImage.enabled = false;
        }
        else
        {
            myRankImage.enabled = true;
        }
        if (Time.frameCount % 15 == 0 && lm.sceneMode == LobbyManager.SceneMode.Battle)
        {
           // 0.25秒ごとに順位を取得する（戦闘シーンのみ動作）
           rank = rankCalc.GetScore(this);
        }
        // 一時保存用変数と現在の順位が違えばUIを切り替える
        if (oldRank != rank)
        {
            // 順位UIを切り替える
            myRankImage.sprite = imageSouces[rank];
            oldRank = rank;
        }
	}
    public void Ready()
    {
        readyImage.sprite = readyOkImage;
    }
}
