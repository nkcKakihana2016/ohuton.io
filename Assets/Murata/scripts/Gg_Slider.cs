using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gg_Slider : MonoBehaviour
{
    Slider _Slider;
	void Start ()
    {
        _Slider = GameObject.Find("Gg_Slider").GetComponent<Slider>();
	}
    float _Gg = 0;
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.O))
        {
            _Gg += 1;
            if (_Gg > _Slider.maxValue)
            {
                _Gg = 5;
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            _Gg -= 1;
            if (_Gg < _Slider.minValue)
            {
                _Gg = 0;
            }
        }


        _Slider.value = _Gg;
	}
}
