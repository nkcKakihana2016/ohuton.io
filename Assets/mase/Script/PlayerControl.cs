using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;//速さ
    public float Big;//大きさ
    public GameObject gameobj;


    // Use this for initialization
    void Start ()
    {

        gameobj.GetComponent<delete>();

	}
	
	// Update is called once per frame
	void Update ()
    {

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

        if (speedup)
        {
            //加速
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * speed * Time.deltaTime * 2;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * speed * Time.deltaTime * 2;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += transform.right * speed * Time.deltaTime * 2;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position -= transform.right * speed * Time.deltaTime * 2;
            }
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    //当たり判定
    //    if (other.gameObject.tag == "point")
    //    {
    //        Destroy(other.gameObject);
    //        //サイズ変更
    //        this.transform.localScale += new Vector3(Big, Big, Big);
    //    }
    //}
}
