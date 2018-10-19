using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleController : MonoBehaviour
{
    public float speed;//速さ
    public float Big;//大きさ
    public Text count;//テキスト
    public int countup = 0;//カウント
    public  bool speedup = false;//スピードを上げるフラグ
    GameObject Acceleratorline;
    Gg_Slider MurataScript;

    // Use this for initialization
    void Start ()
    {
        Acceleratorline = GameObject.Find("Gg_Slider");
        MurataScript = Acceleratorline.GetComponent<Gg_Slider>();
        speedup = true;//スタートしたら使える

    }
	
	// Update is called once per frame
	void Update ()
    {
        //カウントの判定
        if (speedup)
        {
            MurataScript.GAGE();
            //speedup = true;//5以上になったらtrue
            Debug.Log("参照したんご");
        }
        futonpurge();


        //移動
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //当たり判定
        if (other.gameObject.tag == "point")
        {
            //countup += 1;//とったら1ずつ上がっていく
            //SetCount();
            Destroy(other.gameObject);
            MurataScript.GetComponent<Gg_Slider>()._Gg += 10;
            speedup = true;

            Debug.Log("このはげー");
            //サイズ変更
            this.transform.localScale += new Vector3(Big, Big, Big);
        }
    }

    public void futonpurge()
    {
        if (speedup)
        {
            //加速
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * speed * 2 * Time.deltaTime;
                MurataScript.GetComponent<Gg_Slider>()._Gg -= 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * speed * 2 * Time.deltaTime;
                MurataScript.GetComponent<Gg_Slider>()._Gg -= 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * speed * 2 * Time.deltaTime;
                MurataScript.GetComponent<Gg_Slider>()._Gg -= 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * speed * 2 * Time.deltaTime;
                MurataScript.GetComponent<Gg_Slider>()._Gg -= 1;
            }

            Debug.Log("立ったフラグが立った‼");
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    speedup = false;
            //    Debug.Log("帰ったフラグが帰った!!");
            //}
        }
    }

    //public void SetCount()
    //{
    //    count.text = string.Format("count:{0}", countup);//反映させる
    //}
}
