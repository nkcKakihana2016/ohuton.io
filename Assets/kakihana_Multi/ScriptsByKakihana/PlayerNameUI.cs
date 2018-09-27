using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerNameUI : MonoBehaviour {

    // 頭上にプレイヤー名を表示させるスクリプト

    // 表示させるUIの位置調整用ベクトル
    public Vector3 playerUIOffset = new Vector3(0.0f, 2.0f, 0.0f);
    // プレイヤー名をここに保存
    public Text playerNameText;

    // プレイヤー情報（アタッチされてるか確認するためにSerializeFieldにしている）
    [SerializeField] PlayerStatus target;
    // キャラクターの高さ
    float charaHeight;
    // プレイヤーの座標変数（設定されてるか確認するためにSerializeFieldにしている）
    [SerializeField] Transform targetTrans;
    // 追従先の座標
    Vector3 targetPos;


    void Awake()
    {
        // プレイヤー名UIをCanvasの子に設定
        this.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        // キャラクターが居なくなったら名前UIも消える
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    void LateUpdate()
    {
        // キャラクターが存在していたら
        if (targetTrans != null)
        {
            // 自キャラの座標を取得、設定する
            targetPos = targetTrans.position;
            // キャラクターの高さ分、補正をかける
            targetPos.y += charaHeight;

            // カメラのスクリーン座標をもとにプレイヤーに追従する
            this.transform.position = Camera.main.WorldToScreenPoint(targetPos) + playerUIOffset;
        }
    }

    // プレイヤー情報を取得するメソッド
    public void SetTarget(PlayerStatus targetPlayer)
    {
        // プレイヤー情報を取得
        target = targetPlayer;
        Debug.Log("kenti1");
        // プレイヤーのコンポーネントを取得
        targetPlayer.GetComponent<PlayerStatus>();
        // プレイヤー情報より座標コンポーネントを取得
        targetTrans = target.GetComponent<Transform>();
        if (target == null)
        {
            Debug.Log("kenti2");
            return;
        }
        Debug.Log("kenti3");
        // プレイヤー名が設定されていたら
        if (playerNameText != null)
        {
            // プレイヤー名UIのテキストにプレイヤー名を保存
            playerNameText.text = target.photonView.owner.NickName;
            Debug.Log("kenti4");
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	

}
