using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardOn : MonoBehaviour
{
    public GameObject inputtext;
    private TouchScreenKeyboard keyboard;

	// Use this for initialization
	void Start ()
    {
        this.keyboard = TouchScreenKeyboard.Open("初期値", TouchScreenKeyboardType.Default);
        TouchScreenKeyboard.hideInput = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.inputtext.GetComponent<Text>().text = this.keyboard.text;
	}
}
