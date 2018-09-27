using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInputField : MonoBehaviour {

    // マルチ対戦で使用するプレイヤー名を入力、保存するクラス

    static string playerNamePref = "Player1"; // 使用するプレイヤー名

	// Use this for initialization
	void Start () {
        string defaultName = ""; // プレイヤー名の初期設定
        // InputFieldコンポーネント取得
        InputField inputField = this.gameObject.GetComponent<InputField>();
        // 再度マルチ対戦をする際に入力を簡略化するため、前回プレイ時の名前を保存
        if (inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePref))
            {
                defaultName = PlayerPrefs.GetString(playerNamePref);
                inputField.text = defaultName;
            }
        }
	}

    // マルチ対戦で使用するプレイヤー名を設定する
    public void SetPlayerName(Text nameText)
    {
        // テキストコンポーネント取得
        nameText.GetComponent<Text>();
        // Photonに送信する為にstring型変数に保存
        string value = nameText.text;
        // マルチ対戦で使用されるプレイヤー名
        PhotonNetwork.playerName = value + " ";
        // 再度マルチ対戦をする際に入力を簡略化するために現在の名前を保存
        PlayerPrefs.SetString(playerNamePref, value);
        // デバッグ用、プレイヤー名表示
        Debug.Log(PhotonNetwork.player.NickName);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
