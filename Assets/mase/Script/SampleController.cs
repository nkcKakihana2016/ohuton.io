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
    public static bool speedup = false;//スピードを上げるフラグ

    // Use this for initialization
    void Start ()
    {
        speedup = true;//スタートしたら使える
    }
	
	// Update is called once per frame
	void Update ()
    {
        //カウントの判定
        if (countup >= 5)
        {
            speedup = true;//5以上になったらtrue
            Debug.Log("5以上になったんご");
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
            countup += 1;//とったら1ずつ上がっていく
            SetCount();
            Destroy(other.gameObject);
            //サイズ変更
            this.transform.localScale += new Vector3(Big, Big, Big);
        }
    }

    public void futonpurge()
    {
        if (speedup)
        {
            Debug.Log("立ったフラグが立った‼");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                speedup = false;
                Debug.Log("帰ったフラグが帰った!!");
            }
        }
    }

    public void SetCount()
    {
        count.text = string.Format("count:{0}", countup);//反映させる
    }
}
