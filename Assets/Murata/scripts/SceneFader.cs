﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//このスクリプトはゲームマネージャーをつくったら消す
public class SceneFader : MonoBehaviour
{
    GameObject HusumaTest;

    HusumaOC husumaSc;

	void Start ()
    {
        HusumaTest = GameObject.Find("Husuma_test");
        husumaSc = HusumaTest.GetComponent<HusumaOC>();
       
	}

	void Update ()
    {
		if(Input.GetKey(KeyCode.A))
        {
            husumaSc.SceneEfe = 0;
            husumaSc.ChangeScene();
        }
        if(Input.GetKey(KeyCode.S))
        {
            husumaSc.SceneEfe = 1;
            husumaSc.ChangeScene();
        }
	}
}
