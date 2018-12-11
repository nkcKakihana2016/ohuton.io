using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManeger : MonoBehaviour
{
    public Image tapText;
    public string nextSceneName;
    private float speed = 0.03f;

    // Use this for initialization
    void Start ()
    {

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
            SceneManager.LoadScene(nextSceneName);
        }
	}

}
