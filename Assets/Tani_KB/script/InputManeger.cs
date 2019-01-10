using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputManeger : MonoBehaviour
{
    InputField inputField;
    public Text text;


    // InputFieldコンポーネントの取得および初期化メソッドの実行
    // Use this for initialization
    void Start ()
    {
        inputField = GetComponent<InputField>();
        InitInputField();
	}
	
    //出力メソッド
    public void InputLogger()
    {
        string inputValue = inputField.text;
        text.text = inputValue;
        InitInputField();
    }

    void InitInputField()
    {
        //Enter押したら値をリセット
        inputField.text = "";

        //フォーカス
        inputField.ActivateInputField();
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
