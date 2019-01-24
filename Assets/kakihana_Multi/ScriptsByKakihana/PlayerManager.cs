using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerManager : MonoBehaviour {

    // x-10 ~ 10 z20 -15

    public enum Owner
    {
        nosSet = 0,
        player = 1,
        npc = 2
    }

    public int playerID = 0;
    public Owner controllMode = Owner.nosSet;
    [SerializeField] GamePad.Index myPad;

    [SerializeField] LobbyManager lm;
    [SerializeField] Jyroball myPlayer;
    [SerializeField] ControlCamera myCamera;
    // Use this for initialization
    void Start () {
        lm = GameObject.FindObjectOfType<LobbyManager>().GetComponent<LobbyManager>();
        myCamera = GameObject.Find(string.Format("PlayerCam{0}",playerID)).GetComponent<ControlCamera>();
        myCamera.player = this.gameObject;
        myCamera.plyPos = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (GamePad.GetButtonDown(GamePad.Button.B,myPad) && lm.sceneMode == LobbyManager.SceneMode.Lobby)
        {
            lm.Entry(myPad);
        }
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
