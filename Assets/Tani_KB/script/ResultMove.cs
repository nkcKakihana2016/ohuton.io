using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultMove : MonoBehaviour
{
    public float moveX = 0.5f;

    float minAngle = 176.0f;
    float maxAngle = 320.0f;

    public float angle;

    public bool moveFlg;

    float a = 0;

    [SerializeField]
    private float cntTime;　　　　　　　　　　　 //実際の時間制限
    [SerializeField]
    private int checkTime;                       //時間制限（float）をswitch文で使えるようにする変数

    // Use this for initialization
    void Start ()
    {
        moveFlg = true;

        cntTime = 0.0f;　　　　　　　　　　　　 
        checkTime = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        cntTime += Time.deltaTime;
        checkTime = Mathf.CeilToInt(cntTime);

        if (moveFlg == true)
        {
            transform.position -= transform.right * moveX * Time.deltaTime;
        }
        if (checkTime == 18)
        {
            moveFlg = false;
        }


        if (moveFlg ==false)
        {
            if (checkTime >= 20)
            {
                angle = Mathf.LerpAngle(minAngle, maxAngle, a);
                transform.eulerAngles = new Vector3(0, angle, 0);
                a += 0.01f;
                Debug.Log("ふりかえる");
            }
        }
        Debug.Log(angle);
    }

}
