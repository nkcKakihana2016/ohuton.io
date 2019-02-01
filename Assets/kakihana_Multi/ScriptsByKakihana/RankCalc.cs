using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RankCalc : MonoBehaviour {

    // スコアを集計するクラス
    // スコアが多い順に並び替えされる

    [SerializeField] List<ScoreRank> score; // 各プレイヤーのスコア表示クラス
    LobbyManager lm;                        // ロビークラス

	// Use this for initialization
	void Start () {
        // ロビークラスコンポーネント取得
        lm = FindObjectOfType<LobbyManager>().GetComponent<LobbyManager>();
        // 順位の初期設定
        score = score.OrderByDescending(a => a.playerInfo.obutonNum).ThenBy(a => a.playerInfo.playerID).ToList();
    }
	
	// Update is called once per frame
	void Update () {
        // 取得おふとん数を元に降順（おふとんが多い順）に並べ替え
        // おふとんの数が同じ要素が複数あった場合は、プレイヤーIDが若い順に並べ替え
        if (lm.sceneMode == LobbyManager.SceneMode.Battle)
        {
            score = score.OrderByDescending(a => a.playerInfo.obutonNum).ThenBy(a => a.playerInfo.playerID).ToList();
        }
    }

    // 各プレイヤーの情報を格納するメソッド
    public void ScoreEntry(ScoreRank myRank)
    {
        score.Add(myRank);
    }

    // 計算したスコアを各プレイヤーのスコアクラスに送信する
    public int GetScore(ScoreRank myRank)
    {
        // 並び替え後の要素が何番目にあるかを基準に順位を送信する
        int rank = score.IndexOf(myRank);
        return rank;
    }
}
