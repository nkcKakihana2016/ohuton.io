using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManeger : MonoBehaviour
{
    public Image tapText;
    private float speed = 0.04f;

    HusumaOC husumaAnim;

    // Use this for initialization
    void Start ()
    {
        husumaAnim = GameObject.Find("Husuma_test").GetComponent<HusumaOC>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float toColor = tapText.GetComponent<Image>().color.a;
        if(toColor<0||toColor>1)
        {
            speed = speed * -1;
        }

        tapText.GetComponent<Image>().color = new Color(255, 255, 255, toColor + speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            husumaAnim.AnimNum = 1;
            husumaAnim.ChangeScene();

        }
	}

}
