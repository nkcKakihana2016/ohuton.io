using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;//速さ
    public float Big;//大きさ


    // Use this for initialization
    void Start ()
    {
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
