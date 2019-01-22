using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレファブのFutonSetに追加
/// </summary>
public class FtonDestroy : MonoBehaviour {

    //布団エフェクト
    public GameObject EffectObj;

    public GameObject Fton_Bottom;

    public GameObject makura;
	
	void Start ()
    {
        //エフェクトを非表示
        EffectObj.SetActive(false);
	}
	
	
	void Update ()
    {
		
	}
    //当たったら
    public void OnTriggerExit(Collider other)
    {
        //それはPlayerなら
        if (other.gameObject.tag == "Player")
        {
            //エフェクトを表示
            EffectObj.SetActive(true);
            //位置座標
            FindObjectOfType<Fton_Create>().DuplicateFuton(transform.position.x, transform.position.z);
            //このオブジェクトを削除する
            Destroy(gameObject, 1.0f);
            Destroy(Fton_Bottom);
            Destroy(makura);
        }
    }
}
