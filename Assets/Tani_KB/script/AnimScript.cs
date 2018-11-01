using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimScript : MonoBehaviour
{
    //ふすまのアニメーション
    public Animator husumaAnim;
    //タイマーのアニメーション
    public Animator timerAnim;

    //次のシーンを指定
    public string NextSceneName;

    //ふすまのアニメーションをint型で選ぶ
    public int husumaEfe = 0;
    //タイマーのセリフアニメーションをint型で選ぶ
    public int timerEfe = 0;

    // Use this for initialization
    void Start ()
    {
        //アニメーションのBoolをすべてFalseに
        husumaAnim.SetBool("open", false);
        husumaAnim.SetBool("close", false);
        husumaAnim.SetBool("normal", false);
    }

    //ふすまのアニメーションを他スクリプトからケースごとに選んでもらう
    public void ChangeScene()
    {
        switch (husumaEfe)
        {
            case 0://次のシーンへ飛ぶときに使う
                husumaAnim.SetBool("open", false);
                husumaAnim.SetBool("close", true);
                husumaAnim.SetBool("normal", false);
                Invoke("StageSelect", 2.0f);
                break;

            case 1://ゲームシーンの最初に使う
                husumaAnim.SetBool("normal", true);
                husumaAnim.SetBool("close", false);
                break;

            case 2: //リザルトの最初に使う
                husumaAnim.SetBool("open", true);
                husumaAnim.SetBool("close", false);
                Invoke("StageSelect", 3.0f);
                break;
        }
    }

    public void StageSelect()
    {
        SceneManager.LoadScene(NextSceneName);
    }

    //タイマーのセリフアニメーションを他スクリプトからケースごとに選んでもらう
    public void TimerSerif()
    {
        switch(timerEfe)
        {
            case 0://Timerスクリプトで60秒経過時に発動するアニメーション

                break;

            case 1://Timerスクリプトで90秒経過時に発動するアニメーション

                break;

            case 2://Timerスクリプトで105秒経過時に発動するアニメーション

                break;

            case 3://Timerスクリプトで120秒経過時に発動するアニメーション

                break;

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
