using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerManager : MonoBehaviour {

    public enum Owner
    {
        nosSet = 0,
        player = 1,
        npc = 2
    }

    public int playerID = 0;
    public Owner controllMode = Owner.nosSet;
    [SerializeField] GamePad.Index myPad;

    LobbyManager lm;
    Jyroball myPlayer;
    // Use this for initialization
    void Start () {
        lm = GameObject.FindObjectOfType<LobbyManager>().GetComponent<LobbyManager>();
        //playerID = lm.Entry(playerID);
        //switch (playerID)
        //{
        //    case 1:
        //        myPad = GamePad.Index.One;
        //        break;
        //    case 2:
        //        myPad = GamePad.Index.Two;
        //        break;
        //    case 3:
        //        myPad = GamePad.Index.Three;
        //        break;
        //    case 4:
        //        myPad = GamePad.Index.Four;
        //        break;
        //}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init(int id)
    {
        playerID = id;
        switch (id)
        {
            case 1:
                myPad = GamePad.Index.One;
                controllMode = Owner.player;
                break;
            case 2:
                myPad = GamePad.Index.Two;
                break;
            case 3:
                myPad = GamePad.Index.Three;
                break;
            case 4:
                myPad = GamePad.Index.Four;
                break;
        }
    }
}
