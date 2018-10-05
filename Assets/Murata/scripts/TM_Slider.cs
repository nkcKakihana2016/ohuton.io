using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイマー
/// </summary>
public class TM_Slider : MonoBehaviour {
    //タイムスタート時
    public bool ON_TM=true;
    //タイマーslider
    Slider _slider;
    //slider最小値
    float _hp = 0;

    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("TM_Slider").GetComponent<Slider>();
    }

    void Update()
    {
        //タイマー時間
        TIM();
    }
    /// <summary>
    /// タイマー時間
    /// </summary>
    private void TIM()
    {
        //スタート時に合わせる
        if (ON_TM == true)
        {
            // HP上昇
            _hp += Time.deltaTime;
            if (_hp > _slider.maxValue)
            {
                // 最大を超えたら0に戻すコメントアウトで止まる
                //_hp = _slider.minValue;
            }

            // HPゲージに値を設定
            _slider.value = _hp;
        }
    }
}
