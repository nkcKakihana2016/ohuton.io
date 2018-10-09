using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TM_Slider : MonoBehaviour {

    public bool ON_TM=true;
    Slider _slider;
    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("TM_Slider").GetComponent<Slider>();
    }

    float _hp = 0;
    void Update()
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
