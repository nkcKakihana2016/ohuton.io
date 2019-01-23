using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiCamera : MonoBehaviour {

    public enum SpliteCameraMode
    {
        horizontal,
        vertical,
        squere
    }

    SpliteCameraMode mode;

    public Camera player1Cam;
    public Camera player2Cam;
    public Camera player3Cam;
    public Camera player4Cam;

    public Transform frame1;
    public Transform frame2;
    public Transform frame3;
    public Transform frame4;

    // Use this for initialization
    void Start () {
        if (mode == SpliteCameraMode.horizontal)
        {
            player3Cam.gameObject.SetActive(false);
            player4Cam.gameObject.SetActive(false);

            player1Cam.rect = new Rect(0f, 0f, 0.5f, 1f);
            player2Cam.rect = new Rect(0.5f, 0f, 0.5f, 1f);

            var frame1Rect = frame1.Find("Right").GetComponent<RectTransform>();
            frame1Rect.localPosition = new Vector3(frame1Rect.localScale.x / 2f, frame1Rect.localScale.y, frame1Rect.localScale.z);
            var frame2Rect = frame2.Find("Left").GetComponent<RectTransform>();
            frame1Rect.localPosition = new Vector3(frame2Rect.localScale.x / 2f, frame2Rect.localScale.y, frame2Rect.localScale.z);
        }else if(mode == SpliteCameraMode.vertical)
        {
            player3Cam.gameObject.SetActive(false);
            player4Cam.gameObject.SetActive(false);


            player1Cam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
            player2Cam.rect = new Rect(0.0f, 0f, 1f, 0.5f);

            var frame1Rect = frame1.Find("Bottom").GetComponent<RectTransform>();
            frame1Rect.localPosition = new Vector3(frame1Rect.localScale.x, frame1Rect.localScale.y / 2f, frame1Rect.localScale.z);
            var frame2Rect = frame2.Find("Top").GetComponent<RectTransform>();
            frame1Rect.localPosition = new Vector3(frame2Rect.localScale.x, frame2Rect.localScale.y / 2f, frame2Rect.localScale.z);
        }else if(mode == SpliteCameraMode.squere)
        {
            player1Cam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
            player2Cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            player3Cam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
            player4Cam.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);

            var frame1Rect = frame1.Find("Bottom").GetComponent<RectTransform>();
            frame1Rect.localPosition = new Vector3(frame1Rect.localScale.x, frame1Rect.localScale.y / 2f, frame1Rect.localScale.z);
            frame1Rect = frame1.Find("Right").GetComponent<RectTransform>();
            frame1Rect.localPosition = new Vector3(frame1Rect.localScale.x / 2f, frame1Rect.localScale.y, frame1Rect.localScale.z);

            var frame2Rect = frame2.Find("Bottom").GetComponent<RectTransform>();
            frame2Rect.localPosition = new Vector3(frame2Rect.localScale.x, frame2Rect.localScale.y / 2f, frame2Rect.localScale.z);
            frame2Rect = frame2.Find("Left").GetComponent<RectTransform>();
            frame2Rect.localPosition = new Vector3(frame2Rect.localScale.x / 2f, frame2Rect.localScale.y, frame2Rect.localScale.z);

            var frame3Rect = frame3.Find("Top").GetComponent<RectTransform>();
            frame3Rect.localPosition = new Vector3(frame3Rect.localScale.x, frame3Rect.localScale.y / 2f, frame3Rect.localScale.z);
            frame3Rect = frame3.Find("Right").GetComponent<RectTransform>();
            frame3Rect.localPosition = new Vector3(frame3Rect.localScale.x / 2f, frame3Rect.localScale.y, frame3Rect.localScale.z);

            var frame4Rect = frame4.Find("Top").GetComponent<RectTransform>();
            frame4Rect.localPosition = new Vector3(frame4Rect.localScale.x, frame4Rect.localScale.y / 2f, frame4Rect.localScale.z);
            frame4Rect = frame4.Find("Left").GetComponent<RectTransform>();
            frame4Rect.localPosition = new Vector3(frame4Rect.localScale.x / 2f, frame4Rect.localScale.y, frame4Rect.localScale.z);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
