using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerMultiUI : NetworkBehaviour {

    [SerializeField]GameObject myCharaObj;
    [SerializeField] Chara myChara;
    [SerializeField]Canvas myCanvas;

	// Use this for initialization
	void Start () {
        // このオブジェクトをキャンバスの子に設定
        this.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
        myChara = myCharaObj.GetComponent<Chara>();
        if (isLocalPlayer)
        {
            this.gameObject.SetActive(true);
            //GetComponentInChildren<Canvas>().enabled = true;
        }
        //else
        //{
        //    this.gameObject.SetActive(false);
        //}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitPlayer(GameObject chara)
    {
        myCharaObj = chara;
    }
}
