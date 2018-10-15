using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    //const int MAX_LENGTH = 4;

    //string inputtedName = "Name";

    //void OnGUI()
    //{
    //    this.inputtedName = GUI.TextField(new Rect(Screen.width / 2 - 50, Screen.height * 1 / 3, 100, 20), this.inputtedName, MAX_LENGTH);
    //}

    TouchScreenKeyboard keyboard;
    string inputtedName = "Name";

    // アタッチしているGameObjectに子オブジェクトとしてGUITextを作成している
    Transform nameText;

    void Start()
    {
        // GUITextを見つける
        this.nameText = gameObject.transform.Find("NameText");

        // キーボードを表示する
        this.keyboard = TouchScreenKeyboard.Open(this.inputtedName, TouchScreenKeyboardType.Default);
    }

    void Update()
    {
        if (this.keyboard.done)  // キーボードが閉じた時
        {
            this.inputtedName = this.keyboard.text;
            //nameText.guiText = this.inputtedName;
        }
    }
}

