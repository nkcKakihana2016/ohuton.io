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

    //次のシーンを指定
    public string NextSceneName;

    //ふすまのアニメーションをint型で選ぶ
    public int SceneEfe = 0;

    bool MoveScene;

    // Use this for initialization
    void Start ()
    {
        //アニメーションのBoolをすべてFalseに
        Husuma.SetBool("open", false);
        Husuma.SetBool("close", false);
        Husuma.SetBool("normal", false);

        MoveScene = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    //他スクリプトからケースごとにアニメーションを選んでもらう
    public void ChangeScene()
    {
       switch(SceneEfe)
        {
            //次のシーンへ飛ぶときに使う
            case 0:
                Husuma.SetBool("open", false);
                Husuma.SetBool("close", true);
                Husuma.SetBool("normal", false);
                Invoke("StageSelect", 2.0f);
                break;

            //ゲームシーンの最初に使う
            case 1:
                Husuma.SetBool("normal", true);
                Husuma.SetBool("close", false);
                break;

            //リザルトの最初に使う
            case 2:
                Husuma.SetBool("open", true);
                Husuma.SetBool("close", false);
                break;
        }
    }

    public void StageSelect()
    {
        SceneManager.LoadScene(NextSceneName);
    }

    ////ゲームシーンの最初に使う
    //public void NormalOpen()
    //{
    //    Husuma.SetBool("close", false);
    //    Husuma.SetBool("normal", true);
    //}

    ////リザルトの最初に使う
    //public void ResultOpen()
    //{
    //    Husuma.SetBool("open", true);
    //    Husuma.SetBool("close", false);
    //}

    ////次のシーンへ飛ぶときに使う
    //public void CloseHusuma()
    //{
    //    Husuma.SetBool("open", false);
    //    Husuma.SetBool("close", true);
    //    Husuma.SetBool("normal", false);
    //}

    //public void StageSelect()
    //{
    //    SceneManager.LoadScene(NextSceneName);

    //}
}
