using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{

    public GameObject player;       //プレイヤーゲームオブジェクトへの参照を格納する Public 変数
    public Vector3 plyPos;

    private Vector3 offset;         //プレイヤーとカメラ間のオフセット距離を格納する Public 変数

    public float moveCameraY;
    public float masCamera;

    void Start()
    {
        //PlayerObjの真上に来るようにする
        plyPos = GameObject.Find("PlayerObj").transform.position;
        transform.position = new Vector3(plyPos.x, 10.0f, plyPos.z);
        //プレイヤーとカメラ間の距離を取得してそのオフセット値を計算し、格納します。
    }

    // 各フレームで、Update の後に LateUpdate が呼び出されます。
    void LateUpdate()
    {
        masCamera = this.gameObject.transform.position.y;

        //ふとんを取得してサイズが変わるときにカメラの距離を変える
        if (moveCameraY != 0)
        {
            //masCamera = Mathf.SmoothStep(this.gameObject.transform.position.y, moveCameraY, Time.time);
            masCamera = moveCameraY;
            transform.position = new Vector3(plyPos.x, masCamera, plyPos.z);
            offset = transform.position - player.transform.position;
        }

        //カメラの transform 位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
        transform.position = player.transform.position + offset;
    }
}
