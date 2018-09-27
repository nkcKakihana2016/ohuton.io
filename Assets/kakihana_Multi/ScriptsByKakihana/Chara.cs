using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour {

    // キャラクタースクリプト Photon動作確認用

    // オンラインに必要なコンポーネントを設定
    public PhotonView myPhotonView;
    public PhotonTransformView myPhotonTransformView;

    // 使用するキャラクターコントローラー
    public CharacterController myCC;

    // カメラ情報
    private Camera mainCam;

    // スピード
    public float speed;
    // 移動ベクトル
    Vector3 pos = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
        // Photonに接続されていたら
        if (myPhotonView.isMine)
        {
            // カメラ情報を取得
            mainCam = Camera.main;
            // カメラスクリプト内にあるターゲット座標変数に自キャラの座標を格納
            mainCam.GetComponent<CameraManager>().target = this.gameObject.transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
        // Photonに接続されていなければ操作できないようにする
        if (!myPhotonView.isMine)
        {
            return;
        }
        Move(); // 移動ベクトル計算メソッド起動
        myCC.Move(pos * Time.deltaTime); // キャラクター移動

        // 同期ズレを減らすためにPhotonTransformViewに送信する移動用ベクトルを
        // キャラクターコントローラーのスピードより取得
        Vector3 velocity = myCC.velocity;
        // 移動用ベクトルをPhotonTransformViewに送信
        myPhotonTransformView.SetSynchronizedValues(velocity, 0);
    }

    void Move()
    {
        // 移動量算出（ベータ版）
        pos.x = Input.GetAxis("Horizontal");
        pos.z = Input.GetAxis("Vertical");
    }
}
