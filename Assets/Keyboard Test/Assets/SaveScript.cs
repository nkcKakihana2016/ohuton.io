using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScript : MonoBehaviour
{
    string str;
    public InputField inputField;
    public Text text;

    public void SaveText()
    {
        str = inputField.text;
        text.text = str;
        inputField.text = "";
    }
}
