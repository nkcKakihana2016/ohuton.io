using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//布団生成スクリプト
public class Fton_Create : MonoBehaviour {
    List<GameObject> list = new List<GameObject>();
    //布団生成プレハブ
    public GameObject FtonPrefab;
    //初期座標を指定
    [SerializeField]
    Vector3 pos;
	void Start ()
    {
        //X方向に
		for(int X = 0; X <= 10; X++)
        {
            //Z方向に
            for(int Z = 0; Z <= 23; Z++)
            {
                var number = Random.Range(1, 101);
                //間隔布団と布団
                var newPos = pos + new Vector3(2 * X, 0.0f, 1.5f * Z);
                //生成
                var obj = Instantiate(FtonPrefab, newPos, transform.rotation) as GameObject;
                list.Add(obj);
                if (number <= 30)
                {
                    obj.SetActive(false);
                }
            }
        }

	}

    public void a()
    {
        foreach(GameObject obj in list)
        {
            var number = Random.Range(1, 101);
            if (number <= 30)
            {
                obj.SetActive(true);
            }
            else
                obj.SetActive(false);
        }
    }
	
	void Update ()
    {
		
	}
}
