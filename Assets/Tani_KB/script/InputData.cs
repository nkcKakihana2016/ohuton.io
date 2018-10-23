using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputData : MonoBehaviour
{
    private Quaternion gyro;
    private GUIStyle labelStyle;

    // Use this for initialization
    void Start ()
    {
        //フォント生成
        this.labelStyle = new GUIStyle();
        this.labelStyle.fontSize = Screen.height / 22;
        this.labelStyle.normal.textColor = Color.white;

        Input.gyro.enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {

        this.gyro = Input.gyro.attitude;
    }
    void OnGUI()
    {
            float x = Screen.width / 10;
            float y = 0;
            float w = Screen.width * 8 / 10;
            float h = Screen.height / 20;

            for (int i = 0; i < 12; i++)
            {
                y = Screen.height / 10 + h * i;
                string text = string.Empty;

                switch (i)
                {
                    case 0://Y
                        text = string.Format("gyro-x:{0}", this.gyro.x);
                        break;
                    case 1://Y
                        text = string.Format("gyro-y:{0}", this.gyro.y);
                        break;
                    case 2://Y
                        text = string.Format("gyro-z:{0}", this.gyro.z);
                        break;
                    case 3://Y
                        text = string.Format("gyro-w:{0}", this.gyro.w);
                        break;
                    default:
                        throw new System.InvalidOperationException();
                }

                GUI.Label(new Rect(x, y, w, h), text, this.labelStyle);
            }
        }
    }


