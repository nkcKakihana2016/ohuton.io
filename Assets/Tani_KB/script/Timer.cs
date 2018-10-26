using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image roadImg;
    public Animation teacherImg;

    public int cntTime = 0;

    // Use this for initialization
    void Start ()
    {
        
	}

    // Update is called once per frame
    void Update()
    {
        if (cntTime < 120)
        {
            TimeCounter();
        }
    }

    public void TimeCounter()
    {
        if (Time.frameCount % 60 == 0)
        {
            cntTime++;
        }

        Debug.Log(cntTime);

        switch (cntTime)
        {
            case 60://制限時間が60秒になった時
                Debug.Log("60秒経過");
                break;
            case 90://制限時間が90秒になった時
                Debug.Log("90秒経過");
                break;
            case 105://制限時間が105秒になった時
                Debug.Log("105秒経過");
                break;
            case 120://制限時間が120秒（ゲーム終了）になった時
                Debug.Log("ゲーム終了");
                break;
        }
    }
}
