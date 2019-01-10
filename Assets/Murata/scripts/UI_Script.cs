using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI表示・非表示
/// </summary>
public class UI_Script : MonoBehaviour
{
    //名前記入欄を表示
    public GameObject UI_Name;
    //名前記入欄をキー入力仕様で表示非表示
    public bool bl_Name;

    //エラーダイアログを表示
    public GameObject UI_Error;
    //エラーダイアログをキー入力仕様で表示非表示
    public bool bl_Error;

    //キャンセルダイアログを表示
    public GameObject UI_Cancel;
    //キャンセルダイアログをキー入力仕様で表示非表示
    public bool bl_Cancel;
    
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        //名前
        NAME();
        //エラー
        ERROR();
        //キャンセル
        CANCEL();
	}

    /// <summary>
    /// 名前表示非表示
    /// </summary>
    private void NAME()
    {
        //Aキーで非表示
        if (Input.GetKeyDown(KeyCode.A) && bl_Name == true)
        {
            bl_Name = false;
            UI_Name.SetActive(false);
        }
        //Aキーで表示
        else if (Input.GetKeyDown(KeyCode.A) && bl_Name == false)
        {
            bl_Name = true;
            UI_Name.SetActive(true);
        }
    }
    
    /// <summary>
    /// エラー表示・非表示
    /// </summary>
    private void ERROR()
    {
        //Sキーで非表示
        if (Input.GetKeyDown(KeyCode.S) && bl_Error == true)
        {
            bl_Error = false;
            UI_Error.SetActive(false);
        }
        //Sキーで表示
        else if (Input.GetKeyDown(KeyCode.S) && bl_Error == false)
        {
            bl_Error = true;
            UI_Error.SetActive(true);
        }
    }

    /// <summary>
    /// キャンセル表示・非表示
    /// </summary>
    private void CANCEL()
    {
        //Dキーで非表示
        if (Input.GetKeyDown(KeyCode.D) && bl_Cancel == true)
        {
            bl_Cancel = false;
            UI_Cancel.SetActive(false);
        }
        //Dキーで表示
        else if (Input.GetKeyDown(KeyCode.D) && bl_Cancel == false)
        {
            bl_Cancel = true;
            UI_Cancel.SetActive(true);
        }
    }
}
