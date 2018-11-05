using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputData : MonoBehaviour
{
    private Vector3 acceleration;
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
        this.acceleration = Input.acceleration;
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
                case 0://X
                    text = string.Format("accel-X:{0}", this.acceleration.x);
                    break;
                case 1://Y
                    text = string.Format("accel-Y:{0}", this.acceleration.y);
                    break;
                case 2://Z
                    text = string.Format("accel-Z:{0}", this.acceleration.z);
                    break;
                //default:
                        //throw new System.InvalidOperationException();
                }

                GUI.Label(new Rect(x, y, w, h), text, this.labelStyle);
            }
        }
    }


