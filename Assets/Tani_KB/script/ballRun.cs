using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;
//Playerにアタッチ
public class ballRun : MonoBehaviour
{
    //public int rotSpeed = 150;

    public bool DamageFlg;

    //スピードを上げるフラグ
    public bool speedup = false;
    GameObject Acceleratorline;
    Gg_Slider MurataScript;
    //ゲージ
    Slider slider;
    public GameObject jyroball;
    // Use this for initialization
    void Start ()
    {
        var id = jyroball.GetComponent<Jyroball>().playerID;
        slider = GameObject.Find(string.Format("Gg_Slider{0}",id)).GetComponent<Slider>();
        Acceleratorline = GameObject.Find(string.Format("Gg_Slider{0}", id));
        MurataScript = Acceleratorline.GetComponent<Gg_Slider>();
        //スタートしたら使える
        speedup = true;
        jyroball.GetComponent<Jyroball>();
    }    
	
	// Update is called once per frame
	void Update ()
    {
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

        public void Move()
    {
        //transform.Rotate(new Vector3(0, rotSpeed, 0) * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "point")
        {
            jyroball.GetComponent<Jyroball>().OhutonPointMaster();

            Destroy(other.gameObject);
            
            MurataScript.GetComponent<Gg_Slider>()._Gg += 1;
            slider.value = MurataScript.GetComponent<Gg_Slider>()._Gg;
            if (MurataScript.GetComponent<Gg_Slider>()._Gg > slider.maxValue)
            {
                MurataScript.GetComponent<Gg_Slider>()._Gg = MurataScript.GetComponent<Gg_Slider>().MAX_Gg;
            } 
            speedup = true;
        }

    }
    //当たって離れたら
    public void OnTriggerExit(Collider other)
    {
        //敷布団のタグを条件として
            if (other.gameObject.tag == "FutonSet")
            {
            FindObjectOfType<Fton_Create>().DuplicateFuton(transform.position.x, transform.position.z);
            //敷布団を1秒後に削除
            Destroy(other.gameObject,1.0f);
        }
    }

        public void futonpurge()
    {
        if (speedup)
        {
            //加速
            //if (GamePad.GetButtonDown(GamePad.Button.LeftStick, jyroball.GetComponent<Jyroball>().myPad) > 0)
            //{
            //    transform.position += transform.forward * jyroball.GetComponent<Jyroball>().rotSpeed * 2 * Time.deltaTime;
            //    //押している間ゲージを1ずつ減らしていく
            //   MurataScript.GetComponent<Gg_Slider>()._Gg -= 1;
            //    slider.value = MurataScript.GetComponent<Gg_Slider>()._Gg;
            //    if (MurataScript.GetComponent<Gg_Slider>()._Gg < slider.minValue)
            //    {
            //        //ゲージが指定した最小値いかにならないよにする
            //        MurataScript.GetComponent<Gg_Slider>()._Gg = MurataScript.GetComponent<Gg_Slider>().MIN_Gg;
            //        speedup = false;
            //    }
            //}
           
            if (GamePad.GetButtonDown(GamePad.Button.LeftStick,jyroball.GetComponent<Jyroball>().myPad))
            {  
                transform.position -= transform.right * jyroball.GetComponent<Jyroball>().rotSpeed * 2 * Time.deltaTime;
                //押している間ゲージを1ずつ減らしていく
               MurataScript.GetComponent<Gg_Slider>()._Gg -= 1;
                slider.value = MurataScript.GetComponent<Gg_Slider>()._Gg;
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
