using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    GameObject husumaMas;

    public string Next_Scene;

	void Start ()
    {
        husumaMas = GameObject.Find("Husuma_test");
	}

    public void StageSelect(string NextSceneName)
    {
        Next_Scene = NextSceneName;
        
    }

	void Update ()
    {
		
	}
}
