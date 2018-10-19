using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{

    public GameObject player;       //プレイヤーゲームオブジェクトへの参照を格納する Public 変数

    private Vector3 offset;         //プレイヤーとカメラ間のオフセット距離を格納する Public 変数

    void Start()
    {
        //PlayerObjの真上に来るようにする
        Vector3 plyPos = GameObject.Find("PlayerObj").transform.position;
        transform.position = new Vector3(plyPos.x, 8.6f, plyPos.z);

        //プレイヤーとカメラ間の距離を取得してそのオフセット値を計算し、格納します。
        offset = transform.position - player.transform.position;
    }

    // 各フレームで、Update の後に LateUpdate が呼び出されます。
    void LateUpdate()
    {
        //カメラの transform 位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
        transform.position = player.transform.position + offset;
    }
}
