using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManeger : MonoBehaviour
{
    public string nextSceneName;
    HusumaOC husuma;


    public float moveX = 0.5f;

    float minAngle = 176.0f;
    float maxAngle = 320.0f;

    public float angle;

    public bool moveFlg;
    bool turnFlg;
    bool lateStartFlg;

    float a = 0;

    [SerializeField]
    private float cntTime;　　　　　　　　　　　 //実際の時間制限
    [SerializeField]
    private int checkTime;                       //時間制限（float）をswitch文で使えるようにする変数

    // Use this for initialization
    void Start ()
    {
        husuma = GameObject.Find("Husuma_test").GetComponent<HusumaOC>();
        husuma.AnimNum = 3;
        husuma.ChangeScene();

        cntTime = 0.0f;
        checkTime = 0;

        turnFlg = false;
        lateStartFlg = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        LateStarting();

        cntTime += Time.deltaTime;
        checkTime = Mathf.CeilToInt(cntTime);


        if(moveFlg == true)
        {
            transform.position -= transform.right * moveX * Time.deltaTime;
        }

        if (checkTime == 25)
        {
            moveFlg = false;
            turnFlg = true;
        }


        if (turnFlg == true)
        {
            if (checkTime >= 27)
            {
                angle = Mathf.LerpAngle(minAngle, maxAngle, a);
                transform.eulerAngles = new Vector3(0, angle, 0);
                a += 0.01f;
                Debug.Log("ふりかえる");
            }
        }
        Debug.Log(angle);

       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

   void LateStarting()
    {
        if(lateStartFlg==true)
        {
            husuma.AnimNum = 3;
            husuma.ChangeScene();
            lateStartFlg = false;
        }
    }

}
