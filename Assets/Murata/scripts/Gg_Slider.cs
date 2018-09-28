using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gg_Slider : MonoBehaviour
{
    //ゲージslider
    Slider _Slider;
    //ゲージ値
    public int _Gg = 0;
    //カメラ
    public GameObject Camera;
    //距離の制限5段階
    public float One, two, three, fore, five; 

    void Start ()
    {
        //Gg_sliderを取得
        _Slider = GameObject.Find("Gg_Slider").GetComponent<Slider>();
    }
   
	void Update ()
    {
        //キー入力O
		if(Input.GetKeyDown(KeyCode.O))
        {
            //値を追加
            _Gg += 1;
            //ゲージの値がMax以上なら
            if (_Gg>_Slider.maxValue)
            {
                //5以上にしない
                _Gg = 5;
            }
        }
        //キー入力P
        if (Input.GetKeyDown(KeyCode.P))
        {
            //値を減少
            _Gg -= 1;
            //ゲージの値がMIN以下なら
            if (_Gg<_Slider.minValue)
            {
                //0以下にしない
                _Gg = 0;
            }
        }

        //5段階移動
        switch (_Gg)
        {
            case 0:
                Camera.transform.position = new Vector3(0f, One, 0f);
                break;
            case 1:
                Camera.transform.position = new Vector3(0f, two, 0f);
                break;
            case 2:
                Camera.transform.position = new Vector3(0f,three, 0f);
                break;
            case 3:
                Camera.transform.position = new Vector3(0f, fore, 0f);
                break;
            case 4:
                Camera.transform.position = new Vector3(0f, five, 0f);
                break;
        }
        //sliderのvalueをゲージと同じにする
        _Slider.value = _Gg;
	}
}
