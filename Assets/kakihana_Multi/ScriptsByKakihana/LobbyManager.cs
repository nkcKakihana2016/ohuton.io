using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;

public class LobbyManager : MonoBehaviour {

    public enum SceneMode
    {
        Lobby = 0,
        Battle
    }


    // ロビークラス

    /*
     【スクリプトの動き】
     ゲームに参加する人数を設定する（１～４人）
     ゲームパッドの接続に応じてIDを割り当てる
     
    */
    public GamePad.Index padID_A, padID_B, padID_C, padID_D; // ゲームパッド識別ID兼、プレイヤーID
    public SceneMode sceneMode = SceneMode.Lobby;

    public GameObject playerObj;
    [SerializeField] GameObject playerObjCheck;

    public int npcCount = 0; // NPCの人数
    public int playerCount = 1;

    public bool readyFlg_A, readyFlg_B, readyFlg_C, readyFlg_D; // 準備完了フラグ

	// Use this for initialization
	void Start () {
        PlayerInit();
	}
	
	// Update is called once per frame
	void Update () {

        padID_A = GamePad.Index.One;
        padID_B = GamePad.Index.Two;
        padID_C = GamePad.Index.Three;
        padID_D = GamePad.Index.Four;

        var pad_A = GamePad.GetState(GamePad.Index.One, false);
        var pad_B = GamePad.GetState(GamePad.Index.Two, false);
        var pad_C = GamePad.GetState(GamePad.Index.Three, false);
        var pad_D = GamePad.GetState(GamePad.Index.Four, false);

        // 1PのみNPCプレイヤーのつい削除が行える
        // NPC追加処理
        if (GamePad.GetButtonDown(GamePad.Button.Y,padID_A) && npcCount < 4)
        {
            npcCount++;
            switch (npcCount)
            {
                case 0:
                    break;
                case 1:
                    Debug.Log("NPCtuika1");
                    break;
                case 2:
                    Debug.Log("NPCtuika2");
                    break;
                case 3:
                    Debug.Log("NPCtuika3");
                    break;
            }
        }else if(GamePad.GetButtonDown(GamePad.Button.A,padID_A) && npcCount != 0 && readyFlg_A == false)
        {
            // NPC削除処理
            npcCount--;
            switch (npcCount)
            {
                case 0:
                    break;
                case 1:
                    Debug.Log("NPCsakujo1");
                    break;
                case 2:
                    Debug.Log("NPCsakujo2");
                    break;
                case 3:
                    Debug.Log("NPCsakujo3");
                    break;
            }
        }

        if (GamePad.GetButtonDown(GamePad.Button.B,padID_A) && readyFlg_A == false)
        {
            readyFlg_A = true;
            Debug.Log("PadA_OK");
        }
        if (GamePad.GetButtonDown(GamePad.Button.B, padID_B) && readyFlg_B == false)
        {
            readyFlg_B = true;
            Debug.Log("PadB_OK");
        }
        if (GamePad.GetButtonDown(GamePad.Button.B, padID_C) && readyFlg_C == false)
        {
            readyFlg_C = true;
            Debug.Log("PadC_OK");
        }
        if (GamePad.GetButtonDown(GamePad.Button.B, padID_D) && readyFlg_D == false)
        {
            readyFlg_D = true;
            Debug.Log("PadD_OK");
        }

        if (GamePad.GetButtonDown(GamePad.Button.A, padID_A) && readyFlg_A == true)
        {
            readyFlg_A = false;
            Debug.Log("PadA_CANCEL");
        }
        if (GamePad.GetButtonDown(GamePad.Button.A, padID_B) && readyFlg_B == true)
        {
            readyFlg_B = false;
            Debug.Log("PadB_CANCEL");
        }
        if (GamePad.GetButtonDown(GamePad.Button.A, padID_C) && readyFlg_C == true)
        {
            readyFlg_C = false;
            Debug.Log("PadC_CANCEL");
        }
        if (GamePad.GetButtonDown(GamePad.Button.A, padID_D) && readyFlg_D == true)
        {
            readyFlg_D = false;
            Debug.Log("PadD_CANCEL");
        }

        if (readyFlg_A == true && readyFlg_B == true && readyFlg_C == true && readyFlg_D == true)
        {
            StartCoroutine("CountDown");
        }
    }

    void PlayerInit()
    {
        for (int i = 0; i < 4; ++i)
        {
            Vector3 randomPos = new Vector3(Random.Range(-8.0f, 8.0f), transform.position.y, Random.Range(-13.0f, 18.0f));
            GameObject instantObj = Instantiate(playerObj, randomPos, transform.rotation) as GameObject;
            instantObj.name = string.Format("Player{0}",playerCount);
            Jyroball player = instantObj.GetComponent<Jyroball>();
            player.Init(playerCount);
            playerCount++;
        }
    }

    public void Entry(GamePad.Index index)
    {
        switch (index)
        {
            case GamePad.Index.One:
                readyFlg_A = true;
                break;
            case GamePad.Index.Two:
                readyFlg_B = true;
                break;
            case GamePad.Index.Three:
                readyFlg_C = true;
                break;
            case GamePad.Index.Four:
                readyFlg_D = true;
                break;
        }
    }

    public bool playerControll(int playerID)
    {
        return true;
    }

    IEnumerator CountDown()
    {
        Debug.Log("3");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("2");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("1");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("GO!");
        sceneMode = SceneMode.Battle;
        yield return new WaitForSeconds(1.0f);
    }
}

    // Update is called once per frame
#region
    
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using GamepadInput;

//public class LobbyManager : MonoBehaviour
//{

//    // ロビークラス

//    /*
//     【スクリプトの動き】
//     ゲームに参加する人数を設定する（１～４人）
//     ゲームパッドの接続に応じてIDを割り当てる
     
//    */

//    public enum Players
//    {
//        Player1 = 0,
//        Player2,
//        Player3,
//        Player4
//    }

//    public GamePad.Index[] padIDList; // ゲームパッド識別ID兼、プレイヤーID

//    public bool[] readyFlgs;

//    // Use this for initialization
//    void Start()
//    {
//    }

//    void Update()
//    {

//        padIDList[(int)Players.Player1] = GamePad.Index.One;
//        padIDList[(int)Players.Player2] = GamePad.Index.Two;
//        padIDList[(int)Players.Player3] = GamePad.Index.Three;
//        padIDList[(int)Players.Player4] = GamePad.Index.Four;

//        var pad_A = GamePad.GetState(GamePad.Index.One, false);
//        var pad_B = GamePad.GetState(GamePad.Index.Two, false);
//        var pad_C = GamePad.GetState(GamePad.Index.Three, false);
//        var pad_D = GamePad.GetState(GamePad.Index.Four, false);

//        if (GamePad.GetButtonDown(GamePad.Button.B, padIDList[(int)Players.Player1]) && readyFlgs[(int)Players.Player1] == false)
//        {
//            readyFlgs[(int)Players.Player1] = true;
//            Debug.Log("PadA_OK");
//        }
//        if (GamePad.GetButtonDown(GamePad.Button.B, padIDList[(int)Players.Player2]) && readyFlgs[(int)Players.Player2] == false)
//        {
//            readyFlgs[(int)Players.Player2] = true;
//            Debug.Log("PadB_OK");
//        }
//        if (GamePad.GetButtonDown(GamePad.Button.B, padIDList[(int)Players.Player3]) && readyFlgs[(int)Players.Player3] == false)
//        {
//            readyFlgs[(int)Players.Player3] = true;
//            Debug.Log("PadC_OK");
//        }
//        if (GamePad.GetButtonDown(GamePad.Button.B, padIDList[(int)Players.Player4]) && readyFlgs[(int)Players.Player4] == false)
//        {
//            readyFlgs[(int)Players.Player4] = true;
//            Debug.Log("PadD_OK");
//        }

//        if (GamePad.GetButtonDown(GamePad.Button.A, padIDList[(int)Players.Player1]) && readyFlgs[(int)Players.Player1] == true)
//        {
//            readyFlgs[(int)Players.Player1] = false;
//            Debug.Log("PadA_CANCEL");
//        }
//        if (GamePad.GetButtonDown(GamePad.Button.A, padIDList[(int)Players.Player2]) && readyFlgs[(int)Players.Player2] == true)
//        {
//            readyFlgs[(int)Players.Player2] = false;
//            Debug.Log("PadB_CANCEL");
//        }
//        if (GamePad.GetButtonDown(GamePad.Button.A, padIDList[(int)Players.Player3]) && readyFlgs[(int)Players.Player3] == true)
//        {
//            readyFlgs[(int)Players.Player3] = false;
//            Debug.Log("PadC_CANCEL");
//        }
//        if (GamePad.GetButtonDown(GamePad.Button.A, padIDList[(int)Players.Player4]) && readyFlgs[(int)Players.Player4] == true)
//        {
//            readyFlgs[(int)Players.Player4] = false;
//            Debug.Log("PadD_CANCEL");
//        }
//    }
//}
#endregion