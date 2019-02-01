using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManeger : MonoBehaviour
{
    public string nextSceneName;
    HusumaOC husuma;

    public GameObject RoomLight;

    public float moveX = 0.5f;

    float minAngle = 176.0f;
    float maxAngle = 320.0f;

    public float angle;

    public bool moveFlg;
    bool turnFlg;
    bool lateStartFlg;

    public Image Rank1;
    public Image Rank2;
    public Image Rank3;
    public Image Rank4;

    private Sprite rank1p;
    private Sprite rank2p;
    private Sprite rank3p;
    private Sprite rank4p;

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
        RoomLight.SetActive(false);

        rank1p = Resources.Load<Sprite>(string.Format("{0}P",));
        Rank1 = Rank1.GetComponent<Image>();

        rank2p = Resources.Load<Sprite>(string.Format("{0}P",));
        Rank2 = Rank2.GetComponent<Image>();

        rank3p = Resources.Load<Sprite>(string.Format("{0}P",));
        Rank3 = Rank3.GetComponent<Image>();

        rank4p = Resources.Load<Sprite>(string.Format("{0}P",));
        Rank4 = Rank4.GetComponent<Image>();
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

            if (checkTime >= 31)
            {
                RoomLight.SetActive(true);
            }

        }
        Debug.Log(angle);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextSceneName);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            Rank1.sprite = rank1p;
            
            Rank2.sprite = rank2p;
            
            Rank3.sprite = rank3p;

            Rank4.sprite = rank4p;
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
