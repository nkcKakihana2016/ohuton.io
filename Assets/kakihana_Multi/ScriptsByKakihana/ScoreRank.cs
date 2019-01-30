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
    public GameObject watchPlayerObj;               // 参照するプレイヤーオブジェクト
    public Jyroball playerInfo;                     // 参照するプレイヤースクリプト

    public WatchPlayer watchPlayer;                 // インスペクター上でどのプレイヤーを参照するか設定する
    [SerializeField] Image myRankImage;             // 順位を表示させるためのUI
    public int rank;                                // 現在の順位
    public Sprite[] imageSouces = new Sprite[4];    // 各順位の画像を格納する変数
	// Use this for initialization
	void Start () {
        // ロビークラスコンポーネント取得
        lm = GameObject.FindObjectOfType<LobbyManager>().GetComponent<LobbyManager>();
        // UI表示用Imageのコンポーネント取得
        myRankImage = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        // 準備完了状態で参照プレイヤーオブジェクトが設定されていない場合
        if (lm.sceneMode == LobbyManager.SceneMode.Start && watchPlayerObj == null)
        {
            // 参照プレイヤーリストをもとにプレイヤーオブジェクトを取得
            watchPlayerObj = GameObject.Find(string.Format("Player{0}", (int)watchPlayer));
            // 参照プレイヤーオブジェクトよりプレイヤーコンポーネント取得
            playerInfo = watchPlayerObj.GetComponent<Jyroball>();
        }
        if (lm.sceneMode == LobbyManager.SceneMode.Lobby)
        {
            // ロビーの場合は順位UIを表示しない
            myRankImage.enabled = false;
        }
        if (Time.frameCount % 10 == 0 && lm.sceneMode == LobbyManager.SceneMode.Battle)
        {
            RankCheck();
        }
	}

    void RankCheck()
    {

        //for (int i = 0; i < playerRank.Length; ++i)
        //{
        //    for (int j = playerRank.Length - 1; j > i; --j)
        //    {
        //        if (playerRank[j].obutonNum < playerRank[j-1].obutonNum )
        //        {
        //            Jyroball temp = playerRank[j];
        //            playerRank[j] = playerRank[j - i];
        //            playerRank[j - i] = temp;
        //        }
        //    }
        //}
    }

}
