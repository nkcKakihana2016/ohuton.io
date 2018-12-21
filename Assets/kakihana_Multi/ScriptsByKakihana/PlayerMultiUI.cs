using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerMultiUI : Photon.MonoBehaviour {

    // プレイヤー専用UIのスクリプト
    // 自分以外のプレイヤーには専用UIは表示されないようにする

    [SerializeField]GameObject myCharaObj;
    [SerializeField] Chara myChara;
    [SerializeField]Canvas myCanvas;

	// Use this for initialization
	void Start () {
        // このオブジェクトをキャンバスの子に設定
        this.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
        // キャラクターのコンポーネントを取得
        myChara = myCharaObj.GetComponent<Chara>();
        // プレイヤーのPhotonViewが一致していたら動作
        if (myChara.myPhotonView.isMine)
        {
            Debug.Log("UIkenti1");
            // UIを表示
            this.gameObject.SetActive(true);
            // 他プレイヤーに自分のUIが見えないようにする
            myChara.myPhotonView.RPC("LocalUI", PhotonTargets.OthersBuffered);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // キャラクターオブジェクトの初期設定
    public void InitPlayer(GameObject chara)
    {
        myCharaObj = chara;
    }

    // 自分のプレイヤー専用UIが他のプレイヤーに見えないようにするメソッド
    [PunRPC]
    public void LocalUI()
    {
        Debug.Log("UIkenti2");
        this.gameObject.SetActive(false);
    }
}
