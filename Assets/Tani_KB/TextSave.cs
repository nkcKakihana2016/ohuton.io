using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSave : MonoBehaviour
{
    string str;
    public InputField inputField;
    public Text text;

    public void TextGo()
    {
        str = inputField.text;
        text.text = str;
        inputField.text = "";
    }

	
}
