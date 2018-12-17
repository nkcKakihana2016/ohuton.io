using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//ここはふすまのアニメーションを動かす

public class HusumaOC : MonoBehaviour
{
    //ふすまのアニメーション
    public Animator Husuma;

    //ふすまのアニメーションをint型で選ぶ
    public int AnimNum;

    //次のシーンを指定
    public string NextSceneName;


    // Use this for initialization
    void Start ()
    {
        //アニメーションのBoolをすべてFalseに
        Husuma.SetBool("open", false);
        Husuma.SetBool("close", false);
        Husuma.SetBool("normal", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
     
    }

    //他スクリプトからケースごとにアニメーションを選んでもらう
    public void ChangeScene()
    {
        switch (AnimNum)
        {
            //次のシーンへ飛ぶときに使う
            case 1:
                Husuma.SetBool("open", false);
                Husuma.SetBool("normal", false);
                Husuma.SetBool("close", true);
                Invoke("StageSelect", 4.0f);
                break;

            //ゲームシーンの最初に使う
            case 2:
                Husuma.SetBool("normal", true);
                Husuma.SetBool("close", false);
                break;

            //リザルトの最初に使う
            case 3:
                Husuma.SetBool("open", true);
                Husuma.SetBool("close", false);
                break;
        }
    }

    //シーン変更用
    void StageSelect()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}
