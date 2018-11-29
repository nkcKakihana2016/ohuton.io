using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

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
    /*
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
            Debug.Log("チェック");
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
    */

    //布団オブジェクト
    [SerializeField]
    private GameObject m_Futon;
    //布団オブジェクトのサイズ
    [SerializeField]
    private float m_FutonSizeX, m_FutonSizeZ;
    //設置開始地点
    [SerializeField]
    private Vector3 m_InstallationPosition;
    //横に設置する最大個数
    [SerializeField]
    private int m_NumberInstalled;
    //設置する最大個数
    private int m_MaximumNumber = 50;
    //現在設置してある個数
    private int count = 0;

    //設置座標リスト
    private List<Coordinate> m_CoordinateList = new List<Coordinate>();
    //設置している場所
    private List<Coordinate> m_InstallationCoordinates = new List<Coordinate>();
    //再設置判定
    [SerializeField]
    private BoolReactiveProperty m_Reinstall = new BoolReactiveProperty(false);

    private void Start()
    {
        //座標一Listの初期設定
        for (int i = 0; i < 264; i++)
        {
            //設置できる座標の位置の計算
            var x = i % m_NumberInstalled * m_FutonSizeX+m_InstallationPosition.x;
            var z = i / m_NumberInstalled * m_FutonSizeZ+m_InstallationPosition.z;
            //クラスを作成し、Listに保存
            var coordinate = new Coordinate(x, z);
            m_CoordinateList.Add(coordinate);
        }
        //布団の設置開始
        while (count < m_MaximumNumber)
        {
            //被っているものを除いてListに保存 
            List<Coordinate> list = new List<Coordinate>();
            foreach (Coordinate cor in m_CoordinateList)
            {
                if (!m_InstallationCoordinates.Any(c => c.x == cor.x && c.z == cor.z))
                    if (!list.Any(c => c.x == cor.x && c.z == cor.z))
                        list.Add(cor);
            }

            //どこに設置するかランダムで決める
            var number = Random.Range(0, list.Count);
            var coordinate = m_CoordinateList[number];
            //設置を行う座標を取得
            var pos = new Vector3(coordinate.x, 0, coordinate.z);

            //設置を行い、設置している場所のListに加え、設置数を増やす
            Instantiate(m_Futon, pos, Quaternion.identity);
            m_InstallationCoordinates.Add(coordinate);
            count += 1;
        }
        Debug.Log(count);
        //再設置処理
        m_Reinstall.Where(c => c)
            .Subscribe(c =>
            {
                Observable.Timer(System.TimeSpan.FromSeconds(0.1f))
                .Subscribe(_ =>
                {
                    while (count < m_MaximumNumber)
                    {
                        //被っているものを除いてListに保存 
                        List<Coordinate> list = new List<Coordinate>();
                        foreach (Coordinate cor in m_CoordinateList)
                        {
                            if (!m_InstallationCoordinates.Any(n => n.x == cor.x && n.z == cor.z))
                                if (!list.Any(n => n.x == cor.x && n.z == cor.z))
                                    list.Add(cor);
                        }

                        //どこに設置するかランダムで決める
                        var number = Random.Range(0, list.Count);
                        var coordinate = m_CoordinateList[number];
                        //設置を行う座標を取得
                        var pos = new Vector3(coordinate.x, 0, coordinate.z);

                        //設置を行い、設置している場所のListに加え、設置数を増やす
                        Instantiate(m_Futon, pos, Quaternion.identity);
                        m_InstallationCoordinates.Add(coordinate);
                        count += 1;

                        Debug.Log(count);
                        m_Reinstall.Value = count >= m_MaximumNumber ? false : true;
                    }
                }).AddTo(this);
            }).AddTo(this);
    }

    //布団の破壊処理
    public void DuplicateFuton(float x, float z)
    {
        //設置されていた場所のListを削除
        var coordinate = m_InstallationCoordinates.FirstOrDefault(c => c.x == x && c.z == z);
        if (coordinate != null)
            m_InstallationCoordinates.Remove(coordinate);
        //設置されている個数を減らし再設置開始
        count -= 1;

        if (!m_Reinstall.Value)
            m_Reinstall.Value = true;
    }

    /// 座標クラス
    public class Coordinate
    {
        public readonly float x;
        public readonly float z;

        public Coordinate(float x, float z)
        {
            this.x = x;
            this.z = z;
        }
    }
}




