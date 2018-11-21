using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//布団生成スクリプト
public class Fton_Create : MonoBehaviour {
    //   List<GameObject> list = new List<GameObject>();
    //   //布団生成プレハブ
    //   public GameObject FtonPrefab;
    //   //初期座標を指定
    //   [SerializeField]
    //   Vector3 pos;
    //void Start ()
    //   {
    //       //X方向に
    //	for(int X = 0; X <= 10; X++)
    //       {
    //           //Z方向に
    //           for(int Z = 0; Z <= 23; Z++)
    //           {
    //               var number = Random.Range(1, 101);
    //               //間隔布団と布団
    //               var newPos = pos + new Vector3(2 * X, 0.0f, 1.5f * Z);
    //               //生成
    //               var obj = Instantiate(FtonPrefab, newPos, transform.rotation) as GameObject;
    //               list.Add(obj);
    //               if (number <= 80)
    //               {
    //                   obj.SetActive(false);
    //               }
    //           }
    //       }

    //}

    //   //ボタンで生成切替
    //   public void a()
    //   {
    //       foreach(GameObject obj in list)
    //       {
    //           var number = Random.Range(1, 101);
    //           if (number <= 20)
    //           {
    //               obj.SetActive(true);
    //           }
    //           else
    //               obj.SetActive(false);
    //       }
    //   }

    //void Update ()
    //   {

    //}

    public GameObject huton;
    private List<Pos> posList = new List<Pos>();

    private int number = 0;

    [SerializeField]
       Vector3 POS;
    private void Start()
    {
        for (int x = 0; x < 11; x++)
        {
            for (int z = 0; z < 24; z++)
            {
                Pos pos = new Pos();
                pos.SetPos(2 * x, 1.5f * z);
                posList.Add(pos);
            }
        }

        for (int i = 0; i < 50; i++)
        {
            int r = Random.Range(0, posList.Count);
            Instantiate(huton, new Vector3(posList[r].pos_X, 0, posList[r].pos_Z)+POS, transform.rotation);
            posList.Remove(posList[r]);

            number += 1;
            Debug.Log(number);
        }
    }
    private void Update()
    {

    }

    private IEnumerator hutonIns()
    {
        while (true)
        {
            if (number >= 50)
                break;

            int r = Random.Range(0, posList.Count);
            Instantiate(huton, new Vector3(posList[r].pos_X, 0, posList[r].pos_Z), transform.rotation);
            posList.Remove(posList[r]);

            number += 1;

            yield return new WaitForSeconds(3.0f);
        }
    }

    public void HutonRemove(float x, float z)
    {
        var pos = new Pos();
        pos.SetPos(x, z);
        posList.Add(pos);

        number -= 1;

        StartCoroutine("hutonIns");
    }

    public class Pos : MonoBehaviour
    {
        public float pos_X;
        public float pos_Z;

        public void SetPos(float x, float z)
        {
            pos_X = x;
            pos_Z = z;
        }
    }
}
