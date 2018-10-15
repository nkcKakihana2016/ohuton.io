using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerSettings :Photon.MonoBehaviour {

    [SerializeField] PhotonPlayer[] playerList;
    [SerializeField] string[] playerNameList;
    [SerializeField] int[] viewIDList;
    [SerializeField] bool[] roomMaster;

	// Use this for initialization
	void Start () {
        playerList = new PhotonPlayer[PhotonNetwork.room.MaxPlayers];
        playerNameList = new string[PhotonNetwork.room.MaxPlayers];
        viewIDList = new int[PhotonNetwork.room.MaxPlayers];
        roomMaster = new bool[PhotonNetwork.room.MaxPlayers];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int MultyPlayerEntry(PhotonPlayer player,string playerName,int viewID)
    {
        switch(viewID /= 1000)
        {
            case 1:
                playerList[0] = player;
                playerNameList[0] = playerName;
                viewIDList[0] = viewID;
                roomMaster[0] = true;
                break;
            case 2:
                playerList[1] = player;
                playerNameList[1] = playerName;
                viewIDList[1] = viewID;
                roomMaster[1] = false;
                break;
            case 3:
                playerList[2] = player;
                playerNameList[2] = playerName;
                viewIDList[2] = viewID;
                roomMaster[2] = false;
                break;
            case 4:
                playerList[3] = player;
                playerNameList[3] = playerName;
                viewIDList[3] = viewID;
                roomMaster[3] = false;
                break;
            case 5:
                playerList[4] = player;
                playerNameList[4] = playerName;
                viewIDList[4] = viewID;
                roomMaster[4] = false;
                break;
            case 6:
                playerList[5] = player;
                playerNameList[5] = playerName;
                viewIDList[5] = viewID;
                roomMaster[5] = false;
                break;
        }
        return viewID / 1000;
    }

}
