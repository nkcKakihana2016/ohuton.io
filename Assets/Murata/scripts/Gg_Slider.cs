using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲージ移動
/// </summary>
public class Gg_Slider : MonoBehaviour
{
    public enum player
    {
        player1 = 1,
        player2,
        player3,
        player4
    }

    public player myPlayer;

    //ゲージslider
    [SerializeField] Slider _Slider;

    public int ohuton_temp;

    //ゲージ値
    public int _Gg = 0;
    //ゲージMax指定
    public int MAX_Gg=0;
    //ゲージMIN指定
    public int MIN_Gg = 0;
    //カメラ
    public GameObject Camera;
    //距離の制限5段階
    public float One, Two
        , Three, Fore, Five,Six;
    GameObject Playerobj;
    //SampleController Masescript;

    [SerializeField] ScoreRank myRank; // ★順位表示UIスクリプト
    [SerializeField] GameObject parentObj;
    [SerializeField] Jyroball jyroball;
    [SerializeField] LobbyManager lm;
    void Start ()
    {
        myRank = GameObject.Find(string.Format("Player{0}UI",(int)myPlayer)).GetComponent<ScoreRank>();
        //Gg_sliderを取得 ★プレイヤーごとに参照するように変更しました
        _Slider = GameObject.Find(string.Format("Gg_Slider{0}",myRank.playerInfo.playerID)).GetComponent<Slider>();
        _Gg = 0;
        // ★プレイヤーの情報を取得
        Playerobj = myRank.watchPlayerObj;
        ohuton_temp = myRank.playerInfo.obutonNum;
        // Masescript = Playerobj.GetComponent<SampleController>();
        jyroball = Playerobj.GetComponent<Jyroball>();
        lm = GameObject.FindObjectOfType<LobbyManager>().GetComponent<LobbyManager>();
    }
   
	void Update ()
    {
        if (lm.sceneMode == LobbyManager.SceneMode.Lobby || lm.sceneMode == LobbyManager.SceneMode.Start)
        {
            _Slider.value = 0;
        }
        _Slider.value = _Gg;
        //ゲージ移動
        //GAGE();
    }

    /// <summary>
    /// ゲージ移動
    /// </summary>
    public void GAGE()
    {
        //キー入力O
        if (Input.GetKeyDown(KeyCode.O))
        {
            //値を追加
            _Gg += 1;
            //ゲージの値がMax以上なら
            if (_Gg > _Slider.maxValue)
            {
                //5以上にしない
                _Gg = MAX_Gg;

            }
        }
        //キー入力P
        if (Input.GetKeyDown(KeyCode.P))
        {
            //値を減少
            _Gg -= 1;
            //ゲージの値がMIN以下なら
            if (_Gg < _Slider.minValue)
            {
                //0以下にしない
                _Gg = MIN_Gg;
                //Masescript.GetComponent<SampleController>().speedup = false;
                Debug.Log("このフラグもう無理ぽ");
                
            }
        }

        //5段階移動
        switch (_Gg)
        {
            case 0:
                Camera.transform.position = new Vector3(0f, One, 0f);
                break;
            case 1:
                Camera.transform.position = new Vector3(0f, Two, 0f);
                break;
            case 2:
                Camera.transform.position = new Vector3(0f, Three, 0f);
                break;
            case 3:
                Camera.transform.position = new Vector3(0f, Fore, 0f);
                break;
            case 4:
                Camera.transform.position = new Vector3(0f, Five, 0f);
                break;
            case 5:
                Camera.transform.position = new Vector3(0f, Six, 0f);
                break;
        }
        //sliderのvalueをゲージと同じにする
        _Slider.value = _Gg;
    }

    public void GG_Count()
    {
        _Gg++;
    }
    public void GG_Count_Down()
    {
        _Gg--;
    }
}
