using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardAndroid : MonoBehaviour
{
    TouchScreenKeyboard keyboard;
    public Text txt;
    private string PlayerName;

	
	public void OpenKeyBoard ()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true, true);
	}
	
    public void PushOkName()
    {

    }

	// Update is called once per frame
	void Update ()
    {
        if (TouchScreenKeyboard.visible==false&&keyboard !=null)
        {
            if(keyboard.done)
            {
                PlayerName = keyboard.text;
                txt.text = "Player" + PlayerName;
                keyboard = null;
            }
        }
        
	}
}
