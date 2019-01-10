using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimScript : MonoBehaviour
{
    //タイマーのアニメーション
    public Animator timerAnim;

    //タイマーのセリフアニメーションをint型で選ぶ
    public int timerEfe;

    // Use this for initialization
    void Start ()
    {
        timerEfe = 0;

        timerAnim.SetBool("60over", false);
        timerAnim.SetBool("90over", false);
        timerAnim.SetBool("105over", false);
        timerAnim.SetBool("120over", false);
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
