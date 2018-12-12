using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManeger : MonoBehaviour
{
    public GameObject ResMas;
    public string nextSceneName;
    HusumaOC husuma;


	// Use this for initialization
	void Start ()
    {
        husuma = GameObject.Find("Husuma_test").GetComponent<HusumaOC>();
        husuma.AnimNum = 3;
        husuma.ChangeScene();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextSceneName);
        }
	}
}
