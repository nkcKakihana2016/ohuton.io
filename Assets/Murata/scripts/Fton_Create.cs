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

    //布団
    public GameObject huton;
    //ポジションリスト
    private List<Pos> posList = new List<Pos>();
    //個数
    private int number = 0;

    [SerializeField]
    //座標
       Vector3 POS;

    private void Start()
    {
        //x座標方向に11
        for (int x = 0; x < 11; x++)
        {
            //Z座標方向に24
            for (int z = 0; z < 24; z++)
            {
                //座標
                Pos pos = new Pos();
                //間隔
                pos.SetPos(2 * x, 1.5f * z);
                //リスト追加
                posList.Add(pos);
            }
        }

        //50個布団を生成
        for (int i = 0; i < 50; i++)
        {
            //ランダムで
            int r = Random.Range(0, posList.Count);
            //布団を生成
            Instantiate(huton, new Vector3(posList[r].pos_X, 0, posList[r].pos_Z)+POS, transform.rotation);
            //リストから削除
            posList.Remove(posList[r]);
            //布団の数+1
            number += 1;
            //何個出ているか
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
            //50以上なら
            if (number >= 50)
                break;//やめる

            int r = Random.Range(0, posList.Count);
            Instantiate(huton, new Vector3(posList[r].pos_X, 0, posList[r].pos_Z), transform.rotation);
            posList.Remove(posList[r]);

            //数+1
            number += 1;

            yield return new WaitForSeconds(3.0f);
        }
    }
    //布団削除
    public void HutonRemove(float x, float z)
    {
        //座標
        var pos = new Pos();
        //間隔
        pos.SetPos(x, z);
        //リスト追加
        posList.Add(pos);
        //布団の数-1
        number -= 1;

        //コルーチン
        StartCoroutine("hutonIns");
    }
    //座標
    public class Pos : MonoBehaviour
    {
        public float pos_X;//x座標
        public float pos_Z;//y座標

        //座標
        public void SetPos(float x, float z)
        {
            pos_X = x;//x座標
            pos_Z = z;//y座標
        }
    }
}
