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
    public int husumaEfe;
    //タイマーのセリフアニメーションをint型で選ぶ
    public int timerEfe;

    // Use this for initialization
    void Start ()
    {
        husumaEfe = 0;
        timerEfe = 0;

        //アニメーションのBoolをすべてFalseに
        husumaAnim.SetBool("open", false);
        husumaAnim.SetBool("close", false);
        husumaAnim.SetBool("normal", false);

        timerAnim.SetBool("60over", false);
        timerAnim.SetBool("90over", false);
        timerAnim.SetBool("105over", false);
        timerAnim.SetBool("120over", false);
    }

    //ふすまのアニメーションを他スクリプトからケースごとに選んでもらう
    public void ChangeScene()
    {
        switch (husumaEfe)
        {
            case 1://次のシーンへ飛ぶときに使う
                husumaAnim.SetBool("open", false);
                husumaAnim.SetBool("close", true);
                husumaAnim.SetBool("normal", false);
                Invoke("StageSelect", 2.0f);
                break;

            case 2://ゲームシーンの最初に使う
                husumaAnim.SetBool("normal", true);
                husumaAnim.SetBool("close", false);
                break;

            case 3: //リザルトの最初に使う
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
            case 1://Timerスクリプトで60秒経過時に発動するアニメーション
                timerAnim.SetBool("60over", true);
                break;

            case 2://Timerスクリプトで90秒経過時に発動するアニメーション
                timerAnim.SetBool("90over", true);
                break;

            case 3://Timerスクリプトで120秒経過時に発動するアニメーション
                timerAnim.SetBool("120over", true);
                break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
