using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{

    // 現在のシーン名
    private string SceneName;
    //次のシーン
    public string NextSceneName;

	void Start ()
    {
        
	}

    public void StageSelect()
    {
        SceneManager.LoadScene(NextSceneName);

    }

	void Update ()
    {
		
	}
}
