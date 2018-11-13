﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ゲージ色変更
public class Gage_Slider_Color : MonoBehaviour {

    //ゲージslider
    Slider _Slider;
    //ゲージ値
    public int _Gg = 0;
    //ゲージMax指定
    public int MAX_Gg = 5;
    //ゲージMIN指定
    public int MIN_Gg = 0;
    //カメラ
    public GameObject Camera;
    //距離の制限5段階
    public float One, Two, Three, Fore, Five, Six;
    public Image Gage_Slider;
    public Image Gage_bottom;
    public float Red, Blue, Gree;
    public Color colorOne = Color.white;
    public Color colorTwo = Color.white;
    public Color colorThree = Color.white;
    public Color colorFore = Color.white;
    public Color colorFive = Color.white;
    public Color colorSix = Color.white;

    void Start()
    {
        //Gg_sliderを取得
        _Slider = GameObject.Find("Gg_Slider").GetComponent<Slider>();
    }

    void Update()
    {
        //ゲージ移動
        GAGE();
    }

    /// <summary>
    /// ゲージ移動
    /// </summary>
    private void GAGE()
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
            }
        }

        //5段階移動
        switch (_Gg)
        {
            case 0:
                Camera.transform.position = new Vector3(0f, One, 0f);
               //Gage_Slider.color = new Color(Red,Gree,Blue);
                //Gage_bottom.color = new Color(Red,Gree,Blue);
                Gage_bottom.color = colorOne;
                Gage_Slider.color = colorOne;
                break;
            case 1:
                Camera.transform.position = new Vector3(0f, Two, 0f);
                // Gage_Slider.color = new Color(Red, Gree, Blue);
                //Gage_bottom.color = new Color(Red, Gree, Blue);
                Gage_bottom.color = colorTwo;
                Gage_Slider.color = colorTwo;
                break;
            case 2:
                Camera.transform.position = new Vector3(0f, Three, 0f);
                //Gage_Slider.color = new Color(Red, Gree, Blue);
                //Gage_bottom.color = new Color(Red, Gree, Blue);
                Gage_bottom.color = colorThree;
                Gage_Slider.color = colorThree;
                break;
            case 3:
                Camera.transform.position = new Vector3(0f, Fore, 0f);
                //Gage_Slider.color = new Color(Red, Gree, Blue);
                //Gage_bottom.color = new Color(Red, Gree, Blue);
                Gage_bottom.color = colorFore;
                Gage_Slider.color = colorFore;
                break;
            case 4:
                Camera.transform.position = new Vector3(0f, Five, 0f);
                //Gage_Slider.color = new Color(Red, Gree, Blue);
                //Gage_bottom.color = new Color(Red, Gree, Blue);
                Gage_bottom.color = colorFive;
                Gage_Slider.color = colorFive;
                break;
            case 5:
                Camera.transform.position = new Vector3(0f, Six, 0f);
                //Gage_Slider.color = new Color(Red, Gree, Blue);
                //Gage_bottom.color = new Color(Red, Gree, Blue);
                Gage_bottom.color = colorSix;
                Gage_Slider.color = colorSix;
                break;
        }
        //sliderのvalueをゲージと同じにする
        _Slider.value = _Gg;
    }
}