using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointhit : MonoBehaviour
{

    public GameObject AImove;
    AIController aIController;
    public Text count;//AIの布団取得時のテキスト
    public int countup = 0;//ポイントを格納

    public void Start()
    {
        countup = 0;
        AImove = GameObject.Find("SampleAI");
        aIController = AImove.GetComponent<AIController>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "point")
        {
            countup += 1;//1上がる
            SetCount();
            Destroy(other.gameObject);
            //Debug.Log("お前消すんご");

            aIController.futongetCount += 1;
            Debug.Log(aIController.futongetCount);

        }
    }

    public void SetCount()
    {
        count.text = string.Format("count:{0}", countup);
    }
}
