using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static string Next_Scene;

	void Start ()
    {
		
	}

    public void StageSelect(string NextSceneName)
    {
        Next_Scene = NextSceneName;
    }

	void Update ()
    {
		
	}
}
