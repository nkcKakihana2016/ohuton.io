using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRank : MonoBehaviour {

    public Jyroball[] playerRank = new Jyroball[4];   // 順位を参照するクラス

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.frameCount % 10 == 0)
        {
            RankCheck();
        }
	}

    public void battleEntry(Jyroball player)
    {
        playerRank[0] = player;
    }

    void RankCheck()
    {
        for (int i = 0; i < playerRank.Length; ++i)
        {
            for (int j = playerRank.Length - 1; j > i; --j)
            {
                if (playerRank[j].obutonNum < playerRank[j-1].obutonNum )
                {
                    Jyroball temp = playerRank[j];
                    playerRank[j] = playerRank[j - i];
                    playerRank[j - i] = temp;
                }
            }
        }
    }

}
