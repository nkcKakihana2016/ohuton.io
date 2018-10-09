using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移単純
/// </summary>
public class SceneFader : MonoBehaviour
{
   //シーン名
    public static string Next_Scene;

	void Start ()
    {
		
	}

    //シーン移動
    public void StageSelect(string NextSceneName)
    {
        //シーン名と同じなら
        Next_Scene = NextSceneName;
        //シーンをロード
        SceneManager.LoadScene(Next_Scene);
    }

	void Update ()
    {
        
	}
}
