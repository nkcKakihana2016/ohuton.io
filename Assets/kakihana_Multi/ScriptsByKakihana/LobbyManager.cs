using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;

public class LobbyManager : MonoBehaviour {

    // ロビークラス

    /*
     【スクリプトの動き】
     ゲームに参加する人数を設定する（１～４人）
     ゲームパッドの接続に応じてIDを割り当てる
     
    */

    public GamePad.Index padID_A, padID_B, padID_C, padID_D; // ゲームパッド識別ID兼、プレイヤーID

    public bool readyFlg_A, readyFlg_B, readyFlg_C, readyFlg_D;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        var pad_A = GamePad.GetState(GamePad.Index.One, false);
        var pad_B = GamePad.GetState(GamePad.Index.Two, false);
        var pad_C = GamePad.GetState(GamePad.Index.Three, false);
        var pad_D = GamePad.GetState(GamePad.Index.Four, false);

        if (pad_A.B == true)
        {
            Debug.Log("PadA_OK");
        }
        if (pad_B.B == true)
        {
            Debug.Log("PadA_OK");
        }

    }
}
