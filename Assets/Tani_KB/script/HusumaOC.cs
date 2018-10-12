using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//ここはふすまのアニメーションを動かす

public class HusumaOC : MonoBehaviour
{
    public Animator Husuma;
    public float SceneTimer = 3.0f;

    //次のシーン
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

    //ゲームシーンの最初に使う
    public void NormalOpen()
    {
        Husuma.SetBool("close", false);
        Husuma.SetBool("normal", true);
    }

    //リザルトの最初に使う
    public void ResultOpen()
    {
        Husuma.SetBool("open", true);
        Husuma.SetBool("close", false);
    }

    //次のシーンへ飛ぶときに使う
    public void CloseHusuma()
    {
        Husuma.SetBool("open", false);
        Husuma.SetBool("close", true);
        Husuma.SetBool("normal", false);
    }

    public void StageSelect()
    {
        SceneManager.LoadScene(NextSceneName);

    }
}
