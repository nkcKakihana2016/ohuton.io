using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;//速さ
    public float Big;//大きさ
    public GameObject obj;//選択するObject
    Extinguish extinguish;


    // Use this for initialization
    void Start ()
    {

        obj = GameObject.Find("Player_capsule");
        extinguish = obj.GetComponent<Extinguish>();

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

        //if ()
        //{

        //}

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
