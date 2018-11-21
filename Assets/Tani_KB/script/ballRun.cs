﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallRun : MonoBehaviour
{
    //public int rotSpeed = 150;

    public bool DamageFlg;

    public Quaternion charaRot;

    //スピードを上げるフラグ
    public bool speedup = false;
    GameObject Acceleratorline;
    Gg_Slider MurataScript;
    //ゲージ
    Slider slider;
    public GameObject jyroball;
    public bool Des = false;
    // Use this for initialization
    void Start ()
    {
        DamageFlg = false;

        slider = GameObject.Find("Gg_Slider").GetComponent<Slider>();
        Acceleratorline = GameObject.Find("Gg_Slider");
        MurataScript = Acceleratorline.GetComponent<Gg_Slider>();
        //スタートしたら使える
        speedup = true;
        jyroball.GetComponent<Jyroball>();
    }    
	
	// Update is called once per frame
	void Update ()
    {
        charaRot = transform.localRotation;

        //ダメージ受けたら（仮）
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    DamageFlg = true;
        //}

        //if (DamageFlg==false)
        //{
        //    //Move();
        //}

        //if (DamageFlg == true)
        //{
        //    StartCoroutine("GetDamage");
        //}

        //カウントの判定
        if (speedup)
        {
            MurataScript.GAGE();
        }
        futonpurge();
    }
    IEnumerator GetDamage()
    {
        //transform.Rotate(new Vector3(0, 0, 0));
        yield return new WaitForSeconds(3.0f);
        DamageFlg = false;
    }

    public void Move()
    {
        //transform.Rotate(new Vector3(0, rotSpeed, 0) * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "point")
        {
            
            Destroy(other.gameObject);
            
           // MurataScript.GetComponent<Gg_Slider>()._Gg += 1;
            if (MurataScript.GetComponent<Gg_Slider>()._Gg > slider.maxValue)
            {
                MurataScript.GetComponent<Gg_Slider>()._Gg = MurataScript.GetComponent<Gg_Slider>().MAX_Gg;
            }
            speedup = true;
            Des = true;
        }
     
    }
    public void OnTriggerExit(Collider other)
    {
        if (Des == true)
        {
            if (other.gameObject.tag == "FutonSet")
            {
                Destroy(other.gameObject);
                Des = false;
            }
        }
    }

        public void futonpurge()
    {
        if (speedup)
        {
            //加速
            if (Input.touchCount>0)
            {
                transform.position += transform.forward * jyroball.GetComponent<Jyroball>().rotSpeed * 2 * Time.deltaTime;
                //押している間ゲージを1ずつ減らしていく
               MurataScript.GetComponent<Gg_Slider>()._Gg -= 1;
                if (MurataScript.GetComponent<Gg_Slider>()._Gg < slider.minValue)
                {
                    //ゲージが指定した最小値いかにならないよにする
                    MurataScript.GetComponent<Gg_Slider>()._Gg = MurataScript.GetComponent<Gg_Slider>().MIN_Gg;
                    speedup = false;

                }
            }
           
            if (Input.GetKey(KeyCode.A))
            {
                
                transform.position -= transform.right * jyroball.GetComponent<Jyroball>().rotSpeed * 2 * Time.deltaTime;
                //押している間ゲージを1ずつ減らしていく
               MurataScript.GetComponent<Gg_Slider>()._Gg -= 1;
                Debug.Log("加速押したよ");
                if (MurataScript.GetComponent<Gg_Slider>()._Gg < slider.minValue)
                {
                    //ゲージが指定した最小値いかにならないよにする
                    MurataScript.GetComponent<Gg_Slider>()._Gg = MurataScript.GetComponent<Gg_Slider>().MIN_Gg;
                    speedup = false;
                }
            }
        }
    }

}
